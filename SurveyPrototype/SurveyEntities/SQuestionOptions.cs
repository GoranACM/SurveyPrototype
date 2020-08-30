/*  
 *  Project: AITResearch
 *  
 *  Developed by: Goran Ilievski
 *  ID: #7108
 *  Date: 30/08/2020
 *  
 *  Subject: Data-Driven Apps
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyPrototype.SurveyEntities
{
    /// <summary>
    /// SQuestionOptions is the object that represents the options in the survey questions
    /// </summary>
    public class SQuestionOptions
    {
        public int qOptionID { get; set; }
        public string qOptionText { get; set; }
        public int qID { get; set; }
        public int? nQuestion { get; set; }
    }
}