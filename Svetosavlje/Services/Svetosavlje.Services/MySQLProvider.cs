﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Svetosavlje.Data_Layer.Interfaces;
using Svetosavlje.Data_Layer;
using Svetosavlje.Data_Layer.Core;
using Svetosavlje.Data_Layer.MySQLServices;

namespace Svetosavlje.Services
{
    class MySQLProvider : IDataProvider
    {
        

        public IList<MailListTopicInfo> GetTopicList(int rows)
        {
            TopicsList list = new TopicsList();

            return list.GetTopicList(rows);

        }

        public IList<PitanjeInfo> GetQuestionList(int topicID, int rows)
        {
            PitanjePastiruService list = new PitanjePastiruService();

            return list.GetQuestionList(topicID, rows);

        }

        public IList<string> GetSaintNamesList(int Mjesec, int Dan)
        {
            PrologService list = new PrologService();

            return list.GetSaintNamesList(Mjesec, Dan);
        }

        public string GetQuote(int Autor, int Mjesec, int Dan)
        {
            Quote quote = new Quote();

            return quote.GetQuote(Autor, Mjesec, Dan);
        }

        public string GetFastingType(int Mjesec, int Dan)
        {
            FastingType fast = new FastingType();

            return fast.GetFastingType(Mjesec, Dan);

        }

        public string GetZachala(int Mjesec, int Dan, int Godina)
        {
            CitanjaList list = new CitanjaList();

            return list.GetZachala(Mjesec, Dan, Godina);

        }




        public IList<PastirTopic> GetPastirTopicList()
        {
            PitanjePastiruService list = new PitanjePastiruService();

            return list.GetPastirTopicList();
        }



        public PitanjeInfo GetPastirQuestion(int questionID)
        {
            PitanjePastiruService question = new PitanjePastiruService();

            return question.GetPastirQuestion(questionID);
        }



        public IList<Prolog> GetSaintNamesAndLivesList(int Mjesec, int Dan)
        {
            PrologService prolog = new PrologService();
            return prolog.GetSaintNamesAndLivesList(Mjesec, Dan);
        }


        public PrologOther GetProlog(int Mjesec, int Dan)
        {
            PrologService prolog = new PrologService();

            return prolog.GetProlog(Mjesec, Dan);
        }

    }
}
