﻿using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Example.App.DtoBiz.Req.Biz
{
    [ProtoContract]
    public class TestExample : IRequest
    {
        [ProtoMember(1)] 
        public string TestName { get; set; }

        [ProtoMember(2)] 
        public string TestMessage { get; set; }

        public TestExample()
        {

        }

        public TestExample(string testName,
            string testMessage)
        {
            TestName = testName;
            TestMessage = testMessage;
        }
    }
}
