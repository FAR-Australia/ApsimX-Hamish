﻿using Models.Core;
using Models.Core.Attributes;
using Models.Core.Run;
using Models.Storage;
using System;

namespace Models.CLEM.Reporting
{
    /// <summary>
    /// A class for custom SQL queries
    /// </summary>
    [Serializable]
    [ViewName("UserInterface.Views.CustomQueryView")]
    [PresenterName("UserInterface.Presenters.CustomQueryPresenter")]
    [ValidParent(ParentType = typeof(ZoneCLEM))]
    [ValidParent(ParentType = typeof(Folder))]
    [ValidParent(ParentType = typeof(CLEMFolder))]
    [ValidParent(ParentType = typeof(ReportResourceLedger))]
    [ValidParent(ParentType = typeof(Report))]
    [ValidParent(ParentType = typeof(ReportPasturePoolDetails))]
    [ValidParent(ParentType = typeof(ReportRuminantHerd))]
    [Description("Creates a datastore view based on an SQL select statement")]
    [Version(1, 1, 0, "New release of this component")]
    [Version(1, 0, 2, "Now generates a database view for accessing the required data")]
    [Version(1, 0, 1, "")]
    public class CustomQuery : Model, IPostSimulationTool
    {
        [Link]
        private IDataStore dataStore = null;

        /// <summary>
        /// Raw text of an SQL select query
        /// </summary>
        public string Sql { get; set; }

        ///// <summary>
        ///// Name of the file containing an SQL query
        ///// </summary>
        //public string Filename { get; set; }

        ///// <summary>
        ///// Name of the table generated by the query
        ///// </summary>
        //public string Tablename { get; set; }

        /// <summary>
        /// Executes the query and stores it post simulation
        /// </summary>
        public void Run()
        {
            try
            {
                // create view
                dataStore.AddView(this.Name, Sql);
            }
            catch(Exception ex)
            {
                if (!ex.Message.Contains("No Table"))
                {
                    throw new ApsimXException(this, ex.Message);
                }
            }
        }
    }
}
