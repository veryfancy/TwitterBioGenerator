using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterBioGenerator.Web
{
    public class Generator
    {
        private Random _random = new Random();
        private List<string> _simpleNouns;
        private List<string> _subjectBoundNouns;
        private List<string> _subjects;
        private List<string> _superfluousAdjectives;
        private List<string> _fullSentences;

        public Generator()
        {
            this._simpleNouns = new List<string>(Data.SimpleNouns);
            this._subjectBoundNouns = new List<string>(Data.SubjectBoundNouns);
            this._subjects = new List<string>(Data.Subjects);
            this._superfluousAdjectives = new List<string>(Data.SuperfluousAdjectives);
            this._fullSentences = new List<string>(Data.FullSentences);
        }

        public string GenerateBio()
        {
            string result = "";
            int bioLength = this.GetRandomBioLength();
            bool done = false;
            while (!done)
            {
                string newSegment = this.GenerateSegment();
                if (newSegment.Length > 0 && result.Length + newSegment.Length + 1 < bioLength)
                {
                    if (result.Length > 0)
                    {
                        result += " ";
                    }

                    result += newSegment;
                }
                else
                {
                    done = true;
                }
            }
            return result;
        }

        public int GetRandomBioLength()
        {
            int num = this._random.Next(100);
            int result;
            if (num < 5)
            {
                result = 160;
            }
            else
            {
                if (num < 20)
                {
                    result = 140;
                }
                else
                {
                    if (num < 50)
                    {
                        result = 120;
                    }
                    else
                    {
                        result = 100;
                    }
                }
            }
            return result;
        }

        public string GenerateSegment()
        {
            string text = "";
            int num = this._random.Next(100);
            if (num < 3)
            {
                text = this.GetRandomFullSentence();
            }
            else
            {
                if (num < 33)
                {
                    text = this.GetRandomSimpleNoun();
                    if (!string.IsNullOrEmpty(text))
                    {
                        if (this._random.Next(2) < 1)
                        {
                            string randomSuperfluousAdjective = this.GetRandomSuperfluousAdjective();
                            if (!string.IsNullOrEmpty(randomSuperfluousAdjective))
                            {
                                text = this.GetRandomSuperfluousAdjective() + " " + text;
                            }
                        }
                        text = this.Sentenceize(text);
                    }
                }
                else
                {
                    text = this.GetRandomSubjectBoundNoun();
                    string randomSubject = this.GetRandomSubject();
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(randomSubject))
                    {
                        if (text == "%aholic" && randomSubject.EndsWith("a"))
                        {
                            text = "%holic";
                        }
                        text = text.Replace("%", randomSubject);
                        if (this._random.Next(2) < 1)
                        {
                            string randomSuperfluousAdjective = this.GetRandomSuperfluousAdjective();
                            if (!string.IsNullOrEmpty(randomSuperfluousAdjective))
                            {
                                text = this.GetRandomSuperfluousAdjective() + " " + text;
                            }
                        }
                        text = this.Sentenceize(text);
                    }
                }
            }
            return text;
        }

        public string GetRandomSimpleNoun()
        {
            string result = this._simpleNouns[this._random.Next(this._simpleNouns.Count<string>())];
            this._simpleNouns.Remove(result);
            return result;
        }

        public string GetRandomSubjectBoundNoun()
        {
            string result = this._subjectBoundNouns[this._random.Next(this._subjectBoundNouns.Count<string>())];
            this._subjectBoundNouns.Remove(result);
            return result;
        }

        public string GetRandomSubject()
        {
            string result = this._subjects[this._random.Next(this._subjects.Count<string>())];
            this._subjects.Remove(result);
            return result;
        }

        public string GetRandomSuperfluousAdjective()
        {
            string result = this._superfluousAdjectives[this._random.Next(this._superfluousAdjectives.Count<string>())];
            this._superfluousAdjectives.Remove(result);
            return result;
        }

        public string GetRandomFullSentence()
        {
            string result = this._fullSentences[this._random.Next(this._fullSentences.Count<string>())];
            this._fullSentences.Remove(result);
            return result;
        }

        public string Sentenceize(string target)
        {
            string result = target;
            bool flag = false;
            if (!string.IsNullOrEmpty(result))
            {
                if (!result.EndsWith("."))
                {
                    flag = true;
                }
                result = char.ToUpper(result[0]) + result.Substring(1) + (flag ? "." : "");
            }
            return result;
        }
    }
}