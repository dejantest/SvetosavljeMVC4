﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Svetosavlje.Data_Layer;

namespace Svetosavlje.Data_Layer.Interfaces
{
    public interface IBlogProvider : INews, IEditorNews, IMissionNews
    {
    }

    public interface INews
    {
        IList<WPBlogModel> GetNews();
    }
    public interface IEditorNews
    {
        IList<WPBlogModel> GetEditorNews();
    }
    public interface IMissionNews
    {
        IList<WPBlogModel> GetMissionNews();
    }

}
