using OPW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace OPW.DAL
{
    public class OPWInitialiser2 : DropCreateDatabaseIfModelChanges<OPWContext2>
    {
        protected override void Seed(OPWContext2 context)
        {
            var authorisation = new List<Authorisation>
                    
            {
            new Authorisation{User_Name = "John Lee", User_Password = "12345678", Company = User_Company.DEASP, Usersect = User_Section.Admin ,Email="jlee@opw.com"},
            new Authorisation{User_Name = "Jeff Holding", User_Password = "12345678", Company = User_Company.OPW, Usersect = User_Section.Elective_Works,Email="jholding@opw.com" },
            new Authorisation{User_Name = "Colm Carberry", User_Password = "12345678", Company = User_Company.DEASP, Usersect = User_Section.Admin,Email="ccarberry@opw.com"},
            new Authorisation{User_Name = "Paul Colemen", User_Password = "12345678", Company = User_Company.OPW, Usersect = User_Section.Storage,Email="pcolemen@opw.com" },
            new Authorisation{User_Name = "Tim Allen", User_Password = "12345678", Company = User_Company.OPW, Usersect = User_Section.MandE_Works ,Email="tallen@opw.com"},
            new Authorisation{User_Name = "Declan Cullen", User_Password = "12345678", Company = User_Company.DEASP, Usersect = User_Section.Accommodation,Email="dcullen@opw.com"},
            new Authorisation{User_Name = "Sinead Murphy", User_Password = "12345678", Company = User_Company.DEASP, Usersect = User_Section.Finance ,Email="smurphy@opw.com"}

            };
            authorisation.ForEach(s => context.Opwauthorisation2.Add(s));
            context.SaveChanges();
            /* (CJC)
              
             try
            {
                authorisation.ForEach(s => context.Opwauthorisation2.Add(s));
                context.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        Console.ReadLine();
                    }
                }
                throw;
            }

        */

            // Property test data
            var property = new List<Property>
            {
            new Property{OPW_Building_code = "B0034", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.DEASP, Cost_Centre = "V4000", Team = Property_Team.Team_North},
            new Property{OPW_Building_code = "B1000", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.DEASP, Cost_Centre = "V4001", Team = Property_Team.Team_North},
            new Property{OPW_Building_code = "B0034", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.Branch_Office, Cost_Centre = "V3370", Team = Property_Team.Team_south},
            new Property{OPW_Building_code = "B0034", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.DEASP, Cost_Centre = "V4567", Team = Property_Team.Team_south},
            new Property{OPW_Building_code = "B0034", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.HSE_Location, Cost_Centre = "V7689", Team = Property_Team.Team_North},
            new Property{OPW_Building_code = "B1234", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.DEASP, Cost_Centre = "V6750", Team = Property_Team.Team_south},
            new Property{OPW_Building_code = "B0034", Address ="AMD,Store Street",County = "Dublin 1", Type = Property_Type.Branch_Office, Cost_Centre = "V4070", Team = Property_Team.Team_North},
            };
            property.ForEach(x => context.Opwproperty2.Add(x));
            context.SaveChanges();

            // Works test data
            var works = new List<Work>
            {
            new Work{Property_ID = "B0034",User_ID = 1, Proj_Code = "001",Project_Desc= "fix sink" , Proj_budget_Requested = 2000, Status = Status.Pending_Approval},
            new Work{Property_ID = "B1000",User_ID = 2, Proj_Code = "001",Project_Desc= "fix Alarm" , Proj_budget_Requested = 2600, Status = Status.Pending_Approval},
            new Work{Property_ID = "B1234",User_ID = 3, Proj_Code = "002",Project_Desc= "fix ticket system" ,Proj_budget_Requested = 5000, Status = Status.Pending_Approval},
            };
            works.ForEach(w => context.Opwwork2.Add(w));
            context.SaveChanges();
        }
             
    }
}