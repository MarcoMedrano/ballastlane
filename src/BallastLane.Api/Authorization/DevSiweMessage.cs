﻿using Nethereum.Siwe.Core;

namespace BallastLane.Api.Authorization;

public class DevSiweMessage : SiweMessage
{
    public DevSiweMessage()
    {
        Domain = "localhost";
        Statement = "Welcome to BallastLane, please sign-in to proceed.";
        // Uri = "https://localhost:5223/";
        Version = "1";
        SetExpirationTime(DateTime.Now.AddDays(7));
        SetNotBefore(DateTime.Now);
    }
}