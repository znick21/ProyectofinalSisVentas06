﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcSistemaVentas.Models.ViewModels
{
    public class CategoriaVM
    {
        public Categoria Categoria { get; set; }

        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}
