using System;
using System.Collections.Generic;
using System.Text;

namespace PecTec.Riot.Core.Interfaces
{
    public interface IPecTecClient
    {
        T PostRequestForItem<T>(string requestUrl, T postObject);
        List<T> PostRequestForList<T>(string requestUrl, T postObject);
        public T GetRequestForItem<T>(string requestUrl);
        public List<T> GetRequestForList<T>(string requestUrl);
    }
}
