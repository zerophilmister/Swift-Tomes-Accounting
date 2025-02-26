﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Rotativa.AspNetCore;
using Swift_Tomes_Accounting.Data;
using Swift_Tomes_Accounting.Helpers;
using Swift_Tomes_Accounting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Swift_Tomes_Accounting.Controllers
{
    public class AccountantController : Controller
    {
        private IConfiguration _configuration;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountantController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Accountant"))
            {
                var account = _db.Account.ToList();

                double current = 0;
                double casset = 0;
                double cliab = 0;

                double roa = 0;
                double neti = 0;
                double tasset = 0;
                double exp = 0;

                double roe = 0;
                double shareeq = 0;

                double margin = 0;
                double rev = 0;

                double turnover = 0;
                double sales = 0;

                double quick = 0;
                double inv = 0;

                foreach (var item in account)
                {
                    if (item.Category == "Asset" && item.SubCategory == "Current")
                    {
                        casset += item.Balance;
                    }
                    if (item.Category == "Liability" && item.SubCategory == "Current")
                    {
                        cliab += item.Balance;
                    }
                    if (item.AccountName == "Merchandise Inventory")
                    {
                        inv += item.Balance;
                    }
                    if (item.AccountName == "Service Revenue")
                    {
                        sales += item.Balance;
                    }
                    if (item.AccountName == "Contributed Capital")
                    {
                        shareeq += item.Balance;
                    }
                    if (item.Category == "Revenue")
                    {
                        rev += item.Balance;
                    }
                    if (item.Category == "Expenses")
                    {
                        exp += item.Balance;
                    }
                    if (item.Category == "Asset")
                    {
                        tasset += item.Balance;
                    }

                }

                neti = rev - exp;

                current = casset / cliab;
                quick = (casset - inv) / cliab;
                roa = (neti / tasset) * 100;
                turnover = sales / (tasset / 2);
                roe = (neti / shareeq) * 100;
                margin = (neti / rev) * 100;



                Ratio ratio = new Ratio()
                {
                    Current = current,
                    RoA = Math.Round(roa, 2),
                    RoE = Math.Round(roe, 2),
                    Margin = Math.Round(margin, 2),
                    Turnover = turnover,
                    Quick = quick

                };

                return View(ratio);
            }
            else if(_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (_signInManager.IsSignedIn(User) && User.IsInRole("Manager"))
            {
                return RedirectToAction("Index", "Manager");
            }
            else if (_signInManager.IsSignedIn(User) && User.IsInRole("Unapproved"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public IActionResult Send()
        {
            var userList = _db.ApplicationUser.ToList();
            List<SelectListItem> users = new List<SelectListItem>();
            foreach (var user in userList)
            {
                SelectListItem li = new SelectListItem
                {
                    Value = user.Email,
                    Text = user.LastName + ", " + user.FirstName + " <" + user.Email + ">"

                };
                users.Add(li);
                ViewBag.Users = users;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Send(Message obj, IFormFile[] attachments)
        {
            var toEmail = obj.ToEmail;
            var subject = obj.Subject;
            var body = obj.Body;
            var mailHelper = new MailHelper(_configuration);
            List<string> fileNames = null;
            if (attachments != null && attachments.Length > 0)
            {
                fileNames = new List<string>();
                foreach (IFormFile attachment in attachments)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", attachment.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        attachment.CopyToAsync(stream);
                    }
                    fileNames.Add(path);
                }
            }
            mailHelper.Send(_configuration["Gmail:Username"], toEmail, subject, body, fileNames);
            return RedirectToAction("Index", "Accountant");
        }

        [HttpGet]
        public IActionResult EventLog()
        {
            var userevents = _db.EventUser.ToList();
            var accountevents = _db.EventAccount.ToList();
            var journalevents = _db.EventJournal.ToList();
            var journal_accounts = _db.Journal_Accounts.ToList();
            var journal_entry = _db.Journalizes.ToList();

            foreach (var journal in journalevents)
            {
                List<Journal_Accounts> templist = new List<Journal_Accounts>();
                foreach (var ja in journal_accounts)
                {

                    if (ja.JournalId == journal.journalId)
                    {
                        templist.Add(ja);
                    }
                }
                journal.journal_accounts = templist;
                foreach (var je in journal_entry)
                {
                    if (je.JournalId == journal.journalId)
                    {
                        journal.journal = je;
                    }
                }
            }



            EventModel EventModel = new EventModel()
            {
                EventUser = userevents,
                EventAccount = accountevents,
                EventJournal = journalevents
            };

            return View(EventModel);
        }

        [HttpGet]
        public IActionResult PostRef(int? id)
        {
            var all_accounts = _db.Journal_Accounts.ToList();
            List<Journal_Accounts> selected_accounts = new List<Journal_Accounts>();
            var jList = _db.Journalizes.ToList();

            foreach (var s in all_accounts)
            {
                if (s.JournalId == id)
                {
                    selected_accounts.Add(s);
                }
            }

            foreach (var s in selected_accounts)
            {
                foreach (var j in jList)
                {
                    if (s.JournalId == j.JournalId && j.isApproved == true)
                    {
                        s.Description = j.Description;
                        s.Type = j.Type;
                        s.IsApproved = true;
                    }
                }
            }

            return View(selected_accounts);
        }
        
        [HttpGet]
        public IActionResult ChartOfAccounts()
        {
            var accountlist = _db.Account.ToList();
            List<AccountDB> CoA_list = new List<AccountDB>();
            foreach (var item in accountlist)
            {
                if (item.ChartOfAccounts && item.Active)
                {
                    CoA_list.Add(item);
                }
            }

            return View(CoA_list);
        }

        [HttpPost]
        public IActionResult ChartOfAccounts(DateTime dateSearch1,
              DateTime dateSearch2, float balanceSearch1, float balanceSearch2)
        {
            var sortList = SearchResult(dateSearch1, dateSearch2, balanceSearch1, balanceSearch2);
            List<AccountDB> resultlist = new List<AccountDB>();
            foreach(var item in sortList)
            {
                if(item.ChartOfAccounts && item.Active)
                {
                    resultlist.Add(item);
                }
            }
            return View(resultlist);

        }        
        public IActionResult Report()
        {

            return View();

        }
        [HttpGet]
        public IActionResult Journalize()
        {
            var accountlist = _db.Account.ToList();
            List<SelectListItem> journalize_list = new List<SelectListItem>();
            foreach (var item in accountlist)
            {
                if (item.ChartOfAccounts && item.Active)
                {
                    SelectListItem journal_item = new SelectListItem() 
                    { 
                        Value = item.AccountName, 
                        Text = item.AccountName 
                    };
                    journalize_list.Add(journal_item);
                }
            }

            Journalize journalize = new Journalize
            {
                AccountList = journalize_list
            };

            journalize.Journal_Accounts.Add(new Journal_Accounts() { JAId = 1 });
            return View(journalize);
        }

        [HttpPost]
        public IActionResult Journalize(Journalize journal)
        {
            var accountlist = _db.Account.ToList();
            List<SelectListItem> journalize_list = new List<SelectListItem>();
            foreach (var item in accountlist)
            {
                if (item.ChartOfAccounts && item.Active)
                {
                    SelectListItem journal_item = new SelectListItem()
                    {
                        Value = item.AccountName,
                        Text = item.AccountName
                    };
                    journalize_list.Add(journal_item);
                }
            }
            journal.AccountList = journalize_list;


            if (ModelState.IsValid)
            {
                double totalcredit = 0;
                double totaldebit = 0;
                List<string> accountnames = new List<string>();
                bool accountnameError = false;
                journal.CreatedOn = DateTime.Now;
                string uniqueFileName = GetUploadedFileName(journal);
                journal.docUrl = uniqueFileName;

                var errorList = _db.ErrorTable.ToList();

                foreach (var item in journal.Journal_Accounts)
                {
                    accountnames.Add(item.AccountName1);
                    accountnames.Add(item.AccountName2);
                    totalcredit += item.Credit;
                    totaldebit += item.Debit;
                    item.CreatedOn = DateTime.Now;
                }
                foreach (var item in accountnames)
                {
                    int count = accountnames.Count(c => c == item && c != null);
                    if (count > 1)
                    {
                        accountnameError = true;
                        break;
                    }
                }
                for (int i = 0; i < journal.Journal_Accounts.Count(); i++)
                {
                    if (journal.Journal_Accounts[i].Credit <= 0 && journal.Journal_Accounts[i].Debit <= 0)
                    {
                        ModelState.AddModelError("", errorList[6].Message);
                        return View(journal);
                    }
                    if (journal.Journal_Accounts[i].AccountName1 == null && journal.Journal_Accounts[i].AccountName2 == null)
                    {
                        ModelState.AddModelError("", errorList[18].Message);
                        return View(journal);
                    }
                }
                if (totalcredit != totaldebit)
                {
                    ModelState.AddModelError("", errorList[7].Message);
                    return View(journal);
                }
                else if (accountnameError)
                {
                    ModelState.AddModelError("", errorList[8].Message);
                    return View(journal);
                }
                
                _db.Journalizes.Add(journal);
                _db.SaveChanges();
                var journalId = _db.Journalizes.Where(u => u == journal).Select(u => u.JournalId).FirstOrDefault();
                EventJournal new_entry = new EventJournal
                {
                    journalId = journalId,
                    eventTime = DateTime.Now,
                    eventType = "Created Journal Entry",
                    isApproved = false,
                    isDenied = false,
                    eventPerformedBy = _userManager.GetUserAsync(User).Result.FirstName + " " + _userManager.GetUserAsync(User).Result.LastName,
                };
                _db.EventJournal.Add(new_entry);
                _db.SaveChanges();
                TempData[SD.Success] = "Journal entry submitted";
                return RedirectToAction("JournalIndex", "Accountant");
            }


            return View(journal);

        }




        public IActionResult CJE()
        {
            var accounts = _db.Account.ToList();
            double total = 0;
            Journalize journal_entry = new Journalize();
            var counter = 0;
            var expense_total = 0.0;
            var revenue_total = 0.0;
            journal_entry.Type = "Closing";
            journal_entry.CreatedOn = DateTime.Now;
            journal_entry.isCJE = true;

            //calculates closing entry length
            for (int i = 0; i < accounts.Count(); i++)
            {
                if (accounts[i].Category == "Expenses" && accounts[i].ChartOfAccounts)
                {
                    counter++;
                }
            }
            counter ++;

            //creates blank indicies for each account in the closing entry
            for (int i = 0; i < counter; i++)
            {
                journal_entry.Journal_Accounts.Add(new Journal_Accounts());
            }
            counter = 0;

            //fills each index with the corresponding account in the closing journal entry
            journal_entry.Journal_Accounts[counter].AccountName1 = "Service Revenue";
            foreach (var item in accounts)
            {
                if (item.Category == "Expenses" && item.ChartOfAccounts)
                {
                    total += item.Balance;
                    expense_total += item.Balance;
                    journal_entry.Journal_Accounts[counter].AccountName2 = item.AccountName;
                    journal_entry.Journal_Accounts[counter].Credit = item.Balance;
                    journal_entry.Journal_Accounts[counter].CreatedOn = DateTime.Now;
                    counter++;
                }
                if (item.Category == "Revenue" && item.ChartOfAccounts)
                {
                    revenue_total += item.Balance;

                }
            }
            journal_entry.Journal_Accounts[counter].AccountName2 = "Retained Earnings";
            journal_entry.Journal_Accounts[counter].Credit = revenue_total - expense_total;
            total += revenue_total - expense_total;
            journal_entry.Journal_Accounts[0].Debit = total;

            //save database changes and redirect             
            _db.Journalizes.Add(journal_entry);
            _db.SaveChanges();
            TempData[SD.Success] = "Closing Journal entry submitted";
            return RedirectToAction("JournalIndex", "Accountant");
        }

        public FileResult DownloadFile(int? id)
        {
            var jList = _db.Journalizes.ToList();

            string fileName = "";
            foreach (var item in jList)
            {
                if (item.JournalId == id)
                {
                    fileName = item.docUrl;
                }
            }



            //Build the File Path.
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "images/") + fileName;

            //string path = "~/images/" + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
        private string GetUploadedFileName(Journalize journalize)
        {
            string uniqueFileName = null;

            if (journalize.Document != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + journalize.Document.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    journalize.Document.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpGet]

        public IActionResult AccountLedger(int? id)
        {
            var sortList = _db.Journal_Accounts.ToList();
            var jList = _db.Journalizes.ToList();

            foreach (var s in sortList)
            {
                foreach (var j in jList)
                {
                    
                    if (s.JournalId == j.JournalId && j.isApproved == true)
                    {
                        s.IsApproved = true;
                        s.Description = j.Description;
                        s.Type = j.Type;
                    }
                }
            }

            if (id == null)
            {
                return NotFound();
            }

            var accountmatch = _db.Account.FirstOrDefault(u => u.AccountNumber == id);
            List<Journal_Accounts> ja = new List<Journal_Accounts>();
            foreach(var item in sortList)
            {
                if(item.IsApproved)
                {
                    ja.Add(item);
                }
            }

            AccountLedger account_ledger = new AccountLedger
            {
                account = accountmatch,
                journal_accounts = ja
            };
            return View(account_ledger);

        }
        [HttpPost]
        public IActionResult AccountLedger(DateTime dateSearch1,
           DateTime dateSearch2, double LedgerID)
        {
            List<Journal_Accounts> approved_results = new List<Journal_Accounts>();
            var sortList = _db.Journal_Accounts.ToList();
            var jList = _db.Journalizes.ToList();
            AccountLedger account_ledger = new AccountLedger();
            var accounts = _db.Account.ToList();
            int counter = 0;

            //selects the account for the ledger
            foreach (var item in accounts)
            {
                if (item.AccountNumber == LedgerID)
                {
                    account_ledger.account = item;
                    break;
                }
            }
            //determines original length of list before filtering
            foreach (var s in sortList)
            {
                foreach (var j in jList)
                {
                    if (s.JournalId == j.JournalId && j.isApproved == true && s.AccountName1 == account_ledger.account.AccountName)
                    {

                        counter++;
                    }
                    if (s.JournalId == j.JournalId && j.isApproved == true && s.AccountName2 == account_ledger.account.AccountName)
                    {
                        counter++;
                    }
                }
            }

            //returns search results
            var searchresult = SearchResult(dateSearch1, dateSearch2);
            foreach (var s in searchresult)
            {
                foreach (var j in jList)
                {
                    if (s.JournalId == j.JournalId && j.isApproved == true && s.AccountName1 == account_ledger.account.AccountName)
                    {                        
                        s.Description = j.Description;
                        s.Type = j.Type;
                        approved_results.Add(s);
                    }
                    if (s.JournalId == j.JournalId && j.isApproved == true && s.AccountName2 == account_ledger.account.AccountName)
                    {
                        s.Description = j.Description;
                        s.Type = j.Type;
                        approved_results.Add(s);
                    }
                }
            }
            account_ledger.journal_accounts = approved_results;
            ViewBag.Search1 = dateSearch1;
            ViewBag.Search2 = dateSearch2;
            ViewBag.Counter = counter;
            return View(account_ledger);
        }
        [HttpPost]
        public IActionResult showEntryType(Journal_Accounts obj)
        {
            
            var jaList = _db.Journal_Accounts.ToList();
            var jList = _db.Journalizes.ToList();
            List<Journal_Accounts> filteredResults = new List<Journal_Accounts>();

            var entryTypes = new List<SelectListItem>();
            entryTypes.Add(new SelectListItem() { Text = "All", Value = "All" });
            entryTypes.Add(new SelectListItem() { Text = "Regular", Value = "Regular" });
            entryTypes.Add(new SelectListItem() { Text = "Adjusting", Value = "Adjusting" });
            entryTypes.Add(new SelectListItem() { Text = "Reversing", Value = "Reversing" });
            entryTypes.Add(new SelectListItem() { Text = "Closing", Value = "Closing" });
            ViewBag.types = entryTypes;

            foreach (var s in jaList)
            {
                foreach (var j in jList)
                {
                    if (s.JournalId == j.JournalId)
                    {
                        s.Description = j.Description;
                        s.Type = j.Type;
                    }

                    if (s.JournalId == j.JournalId && j.isApproved == true)
                    {
                        s.IsApproved = true;
                    }

                    if (s.JournalId == j.JournalId && j.IsRejected == true)
                    {
                        s.Reason = j.Reason;

                    }

                }
            }
            if (obj.SelectedType == "All")
            {
                return View("JournalIndex", jaList);
            }
            else
            {
                foreach(var item in jaList)
                {
                    if(item.Type == obj.SelectedType)
                    {
                        filteredResults.Add(item);
                    }
                }
                return View("JournalIndex", filteredResults);
            }            

        }

        [HttpGet]
        public IActionResult JournalIndex()
        {
            var sortList = _db.Journal_Accounts.ToList();
            var jList = _db.Journalizes.ToList();
            var accountlist = _db.Account.ToList();
            var entryTypes = new List<SelectListItem>();
            entryTypes.Add(new SelectListItem() { Text = "All", Value = "All" });
            entryTypes.Add(new SelectListItem() { Text = "Regular", Value = "Regular" });
            entryTypes.Add(new SelectListItem() { Text = "Adjusting", Value = "Adjusting" });
            entryTypes.Add(new SelectListItem() { Text = "Reversing", Value = "Reversing" });
            entryTypes.Add(new SelectListItem() { Text = "Closing", Value = "Closing" });
            ViewBag.types = entryTypes;

            foreach (var s in sortList)
            {
                foreach (var j in jList)
                {
                    if (s.JournalId == j.JournalId)
                    {
                        s.Description = j.Description;
                        s.Type = j.Type;
                    }
                    if (s.JournalId == j.JournalId && j.isApproved == true)
                    {
                        s.IsApproved = true;
                    }
                    if (s.JournalId == j.JournalId && j.IsRejected == true)
                    {
                        s.Reason = j.Reason;
                    }

                }
            }
            foreach (var item in sortList)
            {
                foreach (var account in accountlist)
                {
                    if (item.AccountName1 == account.AccountName)
                    {
                        item.AccountNumber1 = account.AccountNumber;
                    }
                    if (item.AccountName2 == account.AccountName)
                    {
                        item.AccountNumber2 = account.AccountNumber;
                    }
                }
            }
            return View(sortList);
        }

        [HttpPost]
        public IActionResult JournalIndex(DateTime dateSearch1,
            DateTime dateSearch2)
        {
            var entryTypes = new List<SelectListItem>();
            entryTypes.Add(new SelectListItem() { Text = "All", Value = "All" });
            entryTypes.Add(new SelectListItem() { Text = "Regular", Value = "Regular" });
            entryTypes.Add(new SelectListItem() { Text = "Adjusting", Value = "Adjusting" });
            entryTypes.Add(new SelectListItem() { Text = "Reversing", Value = "Reversing" });
            ViewBag.types = entryTypes;
            var sortList = SearchResult(dateSearch1, dateSearch2);
            var jList = _db.Journalizes.ToList();
            foreach (var s in sortList)
            {
                foreach (var j in jList)
                {
                    if (s.JournalId == j.JournalId)
                    {
                        s.Description = j.Description;
                        s.Type = j.Type;
                    }
                    if (s.JournalId == j.JournalId && j.isApproved == true)
                    {
                        s.IsApproved = true;
                    }
                    if (s.JournalId == j.JournalId && j.IsRejected == true)
                    {
                        s.Reason = j.Reason;
                    }

                }
            }
            return View(sortList);
        }

        [HttpGet]

        public IActionResult AcctEventLog(int? id)
        {

            var all_acctevents = _db.EventAccount.ToList();
            List<EventAccount> select_account = new List<EventAccount>();
            foreach (var acct in all_acctevents)
            {
                if (acct.AfterAccountNumber == id)
                {
                    select_account.Add(acct);
                }
            }
            EventModel eventlist = new EventModel
            {
                EventAccount = select_account
            };
            return View(eventlist);
        }

        public IEnumerable<AccountDB> SearchResult(DateTime date1, DateTime date2, float balance1, float balance2)
        {
            var list = _db.Account.ToList();

            List<AccountDB> activeList = new List<AccountDB>();
            List<AccountDB> resultList = new List<AccountDB>();

            foreach (var item in list)
            {
                if ((item.ChartOfAccounts) && (item.Active))
                {
                    activeList.Add(item);
                }
            }
            if (date1.ToString() != "1/1/0001 12:00:00 AM")
            {
                if (date2.ToString() == "1/1/0001 12:00:00 AM")
                {
                    date2 = DateTime.Now;
                }
                foreach (var item in activeList)
                {
                    if (date1.Date <= item.CreatedOn.Date && item.CreatedOn.Date <= date2.Date)
                    {
                        resultList.Add(item);
                    }
                }
            }

            if ((balance1 > 0) && (balance2 == 0))
            {
                foreach (var item in activeList)
                {
                    if (balance1 <= item.Balance)
                    {
                        resultList.Add(item);
                    }
                }
            }
            if ((balance1 == 0) && (balance2 > 0))
            {
                foreach (var item in activeList)
                {
                    if (item.Balance <= balance2)
                    {
                        resultList.Add(item);
                    }
                }
            }
            if ((balance1 > 0) && (balance2 > 0))
            {
                foreach (var item in activeList)
                {
                    if ((balance1 <= item.Balance) && (item.Balance <= balance2))
                    {
                        resultList.Add(item);
                    }
                }
            }
            return resultList;
        }
        public IEnumerable<Journal_Accounts> SearchResult(DateTime date1, DateTime date2)
        {

            List<Journal_Accounts> activeList = new List<Journal_Accounts>();
            List<Journal_Accounts> resultList = new List<Journal_Accounts>();

            var jaList = _db.Journal_Accounts.ToList();
            var jList = _db.Journalizes.ToList();

            foreach (var s in jaList)
            {
                activeList.Add(s);
            }

            if (date1.ToString() != "1/1/0001 12:00:00 AM")
            {
                if (date2.ToString() == "1/1/0001 12:00:00 AM")
                {
                    date2 = DateTime.Now;
                }
                foreach (var item in activeList)
                {
                    if (date1.Date <= item.CreatedOn.Date && item.CreatedOn.Date <= date2.Date)
                    {
                        resultList.Add(item);
                    }
                }
            }
            return resultList;
        }

        public IActionResult IncomeStatement()
        {
            var list = _db.Account.ToList();
            double totalRev = 0;
            double totalEx = 0;


            List<AccountDB> accounts = new List<AccountDB>();

            foreach (var item in list)
            {
                if (item.Statement == "Income Statement" && item.Balance > 0)
                {
                    accounts.Add(item);

                    if (item.Category == "Revenue")
                    {
                        totalRev += item.Balance;
                    }

                    if (item.Category == "Expenses")
                    {
                        totalEx += item.Balance;
                    }
                }

            }

            IncomeStatement income = new IncomeStatement()
            {
                Accounts = accounts,
                TotalRev = totalRev,
                TotalEx = totalEx,
                Total = totalRev - totalEx,
                CreatedOn = DateTime.Now
            };
            //_db.IncomeStatement.Add(income);
            //_db.SaveChanges();


            return View(income);
        }

        public IActionResult IncomeStatementPDF()
        {
            return new ViewAsPdf("IncomeStatementPDF");
        }



        public IActionResult BalanceSheet()
        {
            var list = _db.Account.ToList();
            double totalAs = 0;
            double totalLi = 0;
            double totalEq = 0;

            double beginRE = 0;
            double netInc = 0;
            double div = 0;
            double rev = 0;
            double exp = 0;
            double endRE = 0;


            List<AccountDB> accounts = new List<AccountDB>();

            foreach (var item in list)
            {
                if (item.Statement == "Balance Sheet" && item.Balance > 0)
                {
                    accounts.Add(item);

                    if (item.Category == "Asset")
                    {
                        if (item.Contra)
                        {
                            totalAs -= item.Balance;
                        }
                        else
                        {
                            totalAs += item.Balance;
                        }
                    }

                    if (item.Category == "Liability")
                    {
                        if (item.Contra)
                        {
                            totalLi -= item.Balance;
                        }
                        else
                        {
                            totalLi += item.Balance;
                        }
                    }

                    if (item.Category == "Equity")
                    {
                        if (item.Contra)
                        {
                            totalEq -= item.Balance;
                        }
                        else
                        {
                            totalEq += item.Balance;
                        }
                    }
                }

                if (item.Balance > 0)
                {

                    if (item.AccountName == "Retained Earnings")
                    {
                        beginRE += item.Balance;
                    }

                    if (item.AccountName == "Common Dividends Payable" || item.AccountName == "Preferred Dividends Payable")
                    {
                        div += item.Balance;
                    }

                    if (item.Category == "Revenue")
                    {
                        rev += item.Balance;
                    }

                    if (item.Category == "Expenses")
                    {
                        exp += item.Balance;

                    }
                }

            }

            netInc = rev - exp;
            endRE = (beginRE + netInc) - div;
            totalEq += endRE;

            BalanceSheet balance = new BalanceSheet()
            {
                Accounts = accounts,
                TotalAs = totalAs,
                TotalLi = totalLi,
                TotalEQ = totalEq,
                EndRE = endRE
            };

            //_db.BalanceSheet.Add(balance);
            //_db.SaveChanges();

            return View(balance);
        }


        public IActionResult BalanceSheetPDF()
        {
            return new ViewAsPdf("BalanceSheetPDF");

        }



        public IActionResult TrialBalance()
        {
            var list = _db.Account.ToList();
            double totalDebit = 0;
            double totalCredit = 0;
            double exp = 0;
            double serrev = 0;
            bool cje = false;


            List<AccountDB> accounts = new List<AccountDB>();

            foreach (var item in list)
            {
                if (item.Balance > 0 || item.AccountName == "Dividends Declared"
                    || item.AccountName == "Retained Earnings")
                {
                    accounts.Add(item);

                    if (item.NormSide == "Left")
                    {
                        totalDebit += item.Balance;
                    }

                    if (item.NormSide == "Right")
                    {
                        totalCredit += item.Balance;

                    }
                }

                if (item.Category == "Expenses")
                {
                    exp += item.Balance;
                }

                if (item.AccountName == "Service Revenue")
                {
                    serrev += item.Balance;
                }
            }

            if (exp == 0 && serrev == 0)
            {
                cje = true;
            }

            TrialBalance trial = new TrialBalance()
            {
                Accounts = accounts,
                TotalDebit = totalDebit,
                TotalCredit = totalCredit,
                CJE = cje
            };

            //_db.TrialBalance.Add(trial);
            //_db.SaveChanges();

            return View(trial);
        }

        public IActionResult TrialBalancePDF()
        {
            return new ViewAsPdf("TrialBalancePDF");

        }


        public IActionResult RetainedEarnings()
        {
            var list = _db.Account.ToList();
            double beginRE = 0;
            double netInc = 0;
            double div = 0;
            double rev = 0;
            double exp = 0;
            double endRE = 0;



            foreach (var item in list)
            {
                if (item.Balance > 0)
                {

                    if (item.AccountName == "Retained Earnings")
                    {
                        beginRE += item.Balance;
                    }

                    if (item.AccountName == "Common Dividends Payable" || item.AccountName == "Preferred Dividends Payable")
                    {
                        div += item.Balance;
                    }

                    if (item.Category == "Revenue")
                    {
                        rev += item.Balance;
                    }

                    if (item.Category == "Expenses")
                    {
                        exp += item.Balance;
                    }
                }

            }

            netInc = rev - exp;
            endRE = (beginRE + netInc) - div;

            RetainedEarnings earnings = new RetainedEarnings()
            {
                BeginRE = beginRE,
                NetInc = netInc,
                Div = div,
                EndRE = endRE
            };

            //_db.RetainedEarnings.Add(earnings);
            //_db.SaveChanges();

            return View(earnings);
        }

        public IActionResult RetainedEarningsPDF()
        {

            return new ViewAsPdf("RetainedEarningsPDF");
        }
    }
}
