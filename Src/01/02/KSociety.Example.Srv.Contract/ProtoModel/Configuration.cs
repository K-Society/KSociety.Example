using KSociety.Base.App.Utility.Dto.Req;
using KSociety.Base.Srv.Dto;

namespace KSociety.Example.Srv.Contract.ProtoModel
{
    public static class Configuration
    {
        public static void ProtoBufConfiguration()
        {
            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ObjectList<Srv.Dto.Book>), true)
                .AddSubType(120, typeof(Srv.Dto.List.GridView.Book));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ModifyFieldReq), true)
                .AddSubType(200, typeof(App.Dto.Req.ModifyField.Book));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(RemoveReq), true)
                .AddSubType(300, typeof(App.Dto.Req.Remove.Book));


        }
    }
}
