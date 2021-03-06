﻿using Microsoft.EntityFrameworkCore;
using ShareITAPI.Interfaces;
using ShareITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShareITAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DB_A57889_shareITContext _context;

        public BaseRepository(DB_A57889_shareITContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetFirstWhere(Func<T, bool> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public List<T> GetWhere(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void SaveEntities()
        {
            _context.SaveChanges();
        }
    }
}
