﻿namespace AFS.Web.Models.DataTable {
    public class DataTableColumnViewModel {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public DataTableSearchViewModel Search { get; set; }
    }
}