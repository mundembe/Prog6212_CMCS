using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using POE_of_Prog.Models;

namespace POE_of_Prog.Services
{
    public class DataService
    {
        private readonly string _dataPath;
        private Dictionary<string, int> _idCounters = new();
        private readonly string _counterFile;

        public DataService()
        {
            _dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            _counterFile = Path.Combine(_dataPath, "counters.json");
            Directory.CreateDirectory(_dataPath);
            LoadCounters();
        }

        private void LoadCounters()
        {
            if (File.Exists(_counterFile))
            {
                var json = File.ReadAllText(_counterFile);
                _idCounters = JsonSerializer.Deserialize<Dictionary<string, int>>(json) ?? new();
            }
            else
            {
                _idCounters = new Dictionary<string, int>
                {
                    { "Admin", 0 },
                    { "Lecturer", 0 },
                    { "Claim", 0 },
                    { "Approval", 0 }
                };
                SaveCounters();
            }
        }

        private void SaveCounters()
        {
            var json = JsonSerializer.Serialize(_idCounters);
            File.WriteAllText(_counterFile, json);
        }

        private int GetNextId(string type)
        {
            _idCounters[type]++;
            SaveCounters();
            return _idCounters[type];
        }

        private string GetFilePath(string type) => Path.Combine(_dataPath, $"{type}.json");

        private List<T> LoadData<T>()
        {
            var type = typeof(T).Name;
            var path = GetFilePath(type);
            if (!File.Exists(path))
                return new List<T>();

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        private void SaveData<T>(List<T> items)
        {
            var type = typeof(T).Name;
            var path = GetFilePath(type);
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText(path, json);
        }

        // Admin methods
        public Admin AddAdmin(Admin admin)
        {
            var admins = LoadData<Admin>();
            admin.AdminId = GetNextId("Admin");
            admins.Add(admin);
            SaveData(admins);
            return admin;
        }

        public Admin GetAdmin(string username, string password)
        {
            var admins = LoadData<Admin>();
            return admins.FirstOrDefault(a => a.Username == username && a.Password == password);
        }

        // Lecturer methods
        public Lecturer AddLecturer(Lecturer lecturer)
        {
            var lecturers = LoadData<Lecturer>();
            lecturer.LecturerId = GetNextId("Lecturer");
            lecturers.Add(lecturer);
            SaveData(lecturers);
            return lecturer;
        }

        public Lecturer GetLecturer(string username, string password)
        {
            var lecturers = LoadData<Lecturer>();
            return lecturers.FirstOrDefault(l => l.Username == username && l.Password == password);
        }

        // Claim methods
        public Claim AddClaim(Claim claim)
        {
            var claims = LoadData<Claim>();
            claim.ClaimId = GetNextId("Claim");
            claims.Add(claim);
            SaveData(claims);
            return claim;
        }

        public List<Claim> GetClaimsWithLecturerDetails()
        {
            var claims = LoadData<Claim>();
            var lecturers = LoadData<Lecturer>();

            var query = from claim in claims
                       join lecturer in lecturers
                       on claim.LecturerId equals lecturer.LecturerId
                       select claim;

            return query.ToList();
        }

        // Approval methods
        public Approval AddApproval(Approval approval)
        {
            var approvals = LoadData<Approval>();
            approval.ApprovalId = GetNextId("Approval");
            approvals.Add(approval);
            SaveData(approvals);
            return approval;
        }

        public List<Approval> GetApprovals()
        {
            return LoadData<Approval>();
        }

        public void UpdateApprovalDecision(int approvalId, string decision)
        {
            var approvals = LoadData<Approval>();
            var approval = approvals.FirstOrDefault(a => a.ApprovalId == approvalId);
            if (approval != null)
            {
                approval.Decision = decision;
                SaveData(approvals);
            }
        }
    }
}