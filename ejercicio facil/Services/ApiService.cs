using ejerciciofacil.Model;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejerciciofacil.Services
{
    public class ApiService
    {
        public NewJsonToModel JsonTo(JsonToModel model)
        {
            TinyMapper.Bind<NewJsonToModel, NewJsonToModel>();

            var newJsonToModel = new NewJsonToModel
            {
                spam = model.Records.FirstOrDefault().ses.receipt.spamVerdict.status == "PASS" ? true : false,
                virus = model.Records.FirstOrDefault().ses.receipt.virusVerdict.status == "PASS" ? true : false,
                dns = (model.Records.FirstOrDefault().ses.receipt.spfVerdict.status == "PASS" && model.Records.FirstOrDefault().ses.receipt.dkimVerdict.status == "PASS" && model.Records.FirstOrDefault().ses.receipt.dmarcVerdict.status == "PASS") ? true : false,
                mes = model.Records.FirstOrDefault().ses.mail.timestamp.ToString("MMMM"),
                retrasado = (model.Records.FirstOrDefault().ses.receipt.processingTimeMillis > 1000) ? true : false,
                emisor = model.Records.FirstOrDefault().ses.mail.source.ToString().Substring(0, model.Records.FirstOrDefault().ses.mail.source.IndexOf("@")),
                receptor = lista(model.Records.FirstOrDefault().ses.mail.destination)
            };

            var x = TinyMapper.Map<NewJsonToModel>(newJsonToModel);
            return x;
        }

        public List<string> lista(List<string> ls)
        {
            List<string> newList = new List<string>();

            foreach (string item in ls)
            {
                newList.Add(item.ToString().Substring(0, item.IndexOf("@")));
            }

            return newList;
        }
    }
}
