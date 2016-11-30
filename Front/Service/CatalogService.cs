﻿using Front.Dao;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Service
{
    public class CatalogService
    {
        private CatalogDao dao;
        public CatalogService()
        {
            dao = new CatalogDao();
        }

        public IList<CatalogEntity> getAll()
        {
            return dao.getAll();
        }
    }
}