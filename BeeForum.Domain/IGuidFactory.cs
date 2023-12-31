﻿namespace BeeForum.Domain
{
    public interface IGuidFactory
    {
        Guid Create();
    }

    public class GuidFactory : IGuidFactory
    {
        public Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}
