using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterBioGenerator.Web
{
    public class Data
    {
        public static string[] SimpleNouns = new string[]
		{
			"analyst", 
			"communicator", 
			"creator", 
			"entrepreneur", 
			"explorer", 
			"gamer", 
            "introvert",
			"organizer", 
			"problem solver", 
			"reader", 
			"student", 
			"thinker", 
			"troublemaker", 
			"writer"
		};
        public static string[] SubjectBoundNouns = new string[]
		{
			"% aficionado", 
			"% junkie", 
			"% enthusiast", 
			"% geek", 
			"% maven", 
			"% expert", 
			"% practitioner", 
			"% evangelist", 
			"% scholar", 
			"% fanatic", 
			"% specialist", 
			"% ninja", 
			"% guru", 
			"% buff", 
			"% nerd", 
			"% advocate", 
			"% fan", 
			"% fanatic", 
			"% lover", 
			"%aholic", 
			"% trailblazer"
		};
        public static string[] Subjects = new string[]
		{
			"alcohol", 
			"bacon", 
			"beer", 
			"coffee", 
			"pop culture", 
			"food", 
			"internet", 
			"music", 
			"social media", 
			"travel", 
			"tv", 
			"twitter", 
			"web", 
			"zombie"
		};
        public static string[] SuperfluousAdjectives = new string[]
		{
			"freelance", 
			"wannabe", 
			"hardcore", 
			"passionate", 
			"professional", 
			"lifelong", 
			"friendly", 
			"total", 
			"general", 
			"certified", 
			"extreme", 
			"typical", 
			"amateur", 
			"incurable", 
			"devoted", 
			"hipster-friendly", 
			"subtly charming", 
			"award-winning", 
			"infuriatingly humble", 
			"evil",
            "proud",
            "avid",
            "unapologetic"
		};
        public static string[] FullSentences = new string[]
		{
			"Falls down a lot.", 
			"Unable to type with boxing gloves on.", 
			"Prone to fits of apathy.", 
			"Friend of animals everywhere.", 
			"Future teen idol.",
		};
    }
}