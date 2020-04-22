﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GroSHDBEntities : DbContext
    {
        public GroSHDBEntities()
            : base("name=GroSHDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GrocsharyItem> GrocsharyItems { get; set; }
        public virtual DbSet<SendReceiveRequest> SendReceiveRequests { get; set; }
        public virtual DbSet<UsersAddress> UsersAddresses { get; set; }
        public virtual DbSet<UsersInfo> UsersInfoes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
    
        public virtual ObjectResult<Nullable<int>> AddNewUser(string firstName, string lastName, string email, string phone, string password, string addressLine, string city, string state, string country, string zipcode, string lat, string lon, ObjectParameter result)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var addressLineParameter = addressLine != null ?
                new ObjectParameter("addressLine", addressLine) :
                new ObjectParameter("addressLine", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("city", city) :
                new ObjectParameter("city", typeof(string));
    
            var stateParameter = state != null ?
                new ObjectParameter("state", state) :
                new ObjectParameter("state", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("country", country) :
                new ObjectParameter("country", typeof(string));
    
            var zipcodeParameter = zipcode != null ?
                new ObjectParameter("zipcode", zipcode) :
                new ObjectParameter("zipcode", typeof(string));
    
            var latParameter = lat != null ?
                new ObjectParameter("lat", lat) :
                new ObjectParameter("lat", typeof(string));
    
            var lonParameter = lon != null ?
                new ObjectParameter("lon", lon) :
                new ObjectParameter("lon", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AddNewUser", firstNameParameter, lastNameParameter, emailParameter, phoneParameter, passwordParameter, addressLineParameter, cityParameter, stateParameter, countryParameter, zipcodeParameter, latParameter, lonParameter, result);
        }
    
        public virtual ObjectResult<GetItems_Result> GetItems(string lat, string lon, Nullable<int> pageNumber, Nullable<int> rowsPerPage, Nullable<int> userId)
        {
            var latParameter = lat != null ?
                new ObjectParameter("lat", lat) :
                new ObjectParameter("lat", typeof(string));
    
            var lonParameter = lon != null ?
                new ObjectParameter("lon", lon) :
                new ObjectParameter("lon", typeof(string));
    
            var pageNumberParameter = pageNumber.HasValue ?
                new ObjectParameter("PageNumber", pageNumber) :
                new ObjectParameter("PageNumber", typeof(int));
    
            var rowsPerPageParameter = rowsPerPage.HasValue ?
                new ObjectParameter("RowsPerPage", rowsPerPage) :
                new ObjectParameter("RowsPerPage", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetItems_Result>("GetItems", latParameter, lonParameter, pageNumberParameter, rowsPerPageParameter, userIdParameter);
        }
    
        public virtual ObjectResult<GetMyItems_Result1> GetMyItems(Nullable<int> pageNumber, Nullable<int> rowsPerPage, Nullable<int> userId)
        {
            var pageNumberParameter = pageNumber.HasValue ?
                new ObjectParameter("PageNumber", pageNumber) :
                new ObjectParameter("PageNumber", typeof(int));
    
            var rowsPerPageParameter = rowsPerPage.HasValue ?
                new ObjectParameter("RowsPerPage", rowsPerPage) :
                new ObjectParameter("RowsPerPage", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMyItems_Result1>("GetMyItems", pageNumberParameter, rowsPerPageParameter, userIdParameter);
        }
    }
}
