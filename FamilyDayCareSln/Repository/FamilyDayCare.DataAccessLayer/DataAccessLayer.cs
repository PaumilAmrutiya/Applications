using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Repository.FamilyDayCare.ClassLibrary;
using Repository.FamilyDayCare.DataModel;
using Repository.HelperClassLibrary;

namespace Repository.FamilyDayCare.DataAccessLayer
{
    public class DataAccessLayer
    {

        #region Oraganisation

        /// <summary>
        /// This method is used to add new oraganisation information
        /// </summary>
        /// <param name="oraganisation"></param>
        public void InsertOraganisation(Oraganisation oraganisation)
        {
            try
            {
                DataContext dataContext = new DataContext();
                dataContext.Oraganisations.Add(oraganisation);
                dataContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        /// <summary>
        /// This method is used to update details of oraganisation
        /// </summary>
        /// <param name="oraganisation"></param>
        public void UpdateOraganisation(Oraganisation oraganisation)
        {
            try
            {
                DataContext dataContext = new DataContext();
                Oraganisation resOraganisation =  dataContext.Oraganisations.Where(o => o.Id == oraganisation.Id).Select(o => o as Oraganisation).FirstOrDefault();
                if (resOraganisation != null)
                {
                    resOraganisation.Name = oraganisation.Name;
                    dataContext.Entry(resOraganisation).State = EntityState.Modified;
                    dataContext.SaveChanges();
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        /// <summary>
        /// This method is used to delete oraganisation information based on key parameters
        /// </summary>
        /// <param name="oraganisation"></param>
        /// <param name="key"></param>
        public void DeleteOraganisation(Oraganisation oraganisation, CommonEnums.SearchKey key)
        {
            try
            {
                DataContext dataContext = new DataContext();
                Oraganisation resOraganisation = new Oraganisation();
                switch (key)
                {
                    case CommonEnums.SearchKey.OraganisationId:
                    {
                        resOraganisation = dataContext.Oraganisations.Find(oraganisation.Id);
                        break;
                    }
                    case CommonEnums.SearchKey.OraganisationName:
                    {
                        resOraganisation = dataContext.Oraganisations.Find(oraganisation.Name);
                        break;
                    }
                    case CommonEnums.SearchKey.RegistrationNumber:
                    {
                        resOraganisation = dataContext.Oraganisations.Find(oraganisation.RegistrationNumber);
                        break;
                    }
                }

                dataContext.Oraganisations.Remove(resOraganisation);
                dataContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// This method is used to search list of oraganisations based on different parameters
        /// </summary>
        /// <param name="oraganisation"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<Oraganisation> SearchOraganisations(Oraganisation oraganisation, CommonEnums.SearchKey key)
        {
            List<Oraganisation> resOraganisations = null;
            DataContext dataContext = new DataContext();
            try
            {
                switch (key)
                {
                    case CommonEnums.SearchKey.SuburbId:
                    {
                        resOraganisations =
                            dataContext.Oraganisations.Where(o => o.SuburbId == oraganisation.SuburbId)
                                .ToList<Oraganisation>();
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return resOraganisations;
        }

        #endregion Oraganisation

        #region Child

        /// <summary>
        /// This method is used to add new child record in oraganisation
        /// </summary>
        /// <param name="child"></param>
        public void InsertChild(Child child)
        {
            try
            {
                DataContext dataContext = new DataContext();
                dataContext.Children.Add(child);
                dataContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// This method is used to delete child record as pere search key
        /// </summary>
        /// <param name="child"></param>
        /// <param name="key"></param>
        public void DeleteChild(Child child, CommonEnums.SearchKey key)
        {
            try
            {
                DataContext dataContext = new DataContext();
                switch (key)
                {
                    case CommonEnums.SearchKey.ChildId:
                    {
                        Child resChild = new Child();
                        resChild = dataContext.Children.Find(child.Id);
                        dataContext.Children.Remove(resChild);
                        break;
                    }
                    case CommonEnums.SearchKey.OraganisationId:
                    {
                        List<Child> resChildren = null;
                        resChildren =
                            dataContext.Children.Where(c => c.OraganisationId == child.OraganisationId).ToList();
                        dataContext.Children.RemoveRange(resChildren);
                        break;
                    }
                }
                dataContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// This method is used to search childern's details based on key parameters
        /// </summary>
        /// <param name="child"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<Child> SearchChildren(Child child , CommonEnums.SearchKey key)
        {
            List<Child> resChildren = null;
            DataContext dataContext = new DataContext();
            try
            {
                switch (key)
                {
                    case CommonEnums.SearchKey.OraganisationId:
                    {
                        resChildren =
                            dataContext.Children.Where(c => c.OraganisationId == child.OraganisationId).ToList<Child>();
                        break;
                    }
                    case CommonEnums.SearchKey.SuburbId:
                    {
                        resChildren = dataContext.Children.Where(c => c.SuburbId == child.SuburbId).ToList<Child>();
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return resChildren;
        }
        #endregion Child
    }
}
