﻿using Ballastlane.Domain.Repositories;
using BallestLane.Dal;
using BallestLane.Entities;

namespace BallestLane.Business;

public class NftService(INftRepository repo) : INftService
{
    public Task<Nft> GetById(long id) => repo.GetById(id);

    public Task<IEnumerable<Nft>> GetAll() => repo.GetAll();

    public Task<long> Add(Nft nft) => repo.Add(nft);

    public Task Update(Nft nft) => repo.Update(nft);

    public Task Delete(long id) => repo.Delete(id);
}
