﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace TestTask.SDK.Models
{
    public sealed class RSSAtomFeed : IFeed
    {
        internal static ILogger Logger { get; set; }

        public string Id { get; }
        public string Description { get; }
        public string TypeDescription { get; }
        public string Link { get; }
        public string Title { get; }
        public DateTime PublishDate { get; }

        public RSSAtomFeed(string id, string description, string typeDescription, string link, string title, DateTime publishDate)
        {
            if (id == null ||
                link == null ||
                title == null ||
                typeDescription == null)
            {
                Logger?.Log(nameof(RSSAtomFeed), nameof(RSSAtomFeed), new ArgumentNullException("Arguments must be not-null"));

                return;
            }

            Id = id;
            Link = link;
            Title = title;
            TypeDescription = typeDescription;

            if (description != null)
                Description = description;
            if (publishDate != null)
                PublishDate = publishDate;
        }

        public override bool Equals(object obj)
        {
            if (obj is RSSAtomFeed)
            {
                RSSAtomFeed y = (RSSAtomFeed)obj;

                if (Id == y.Id &&
                Link == y.Link &&
                PublishDate == y.PublishDate &&
                Title == y.Title &&
                TypeDescription == y.TypeDescription &&
                Description == y.Description)
                    return true;
            }

            return false;
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}