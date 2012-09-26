using System.Collections.Generic;

namespace YA12306
{
    public static class TrainCode
    {
        static readonly Dictionary<string, TrainInfo> TextCodeMap = new Dictionary<string, TrainInfo>()
                                                                        {
                                                                            {"D126", new TrainInfo {Text = "D126（汉口08:06→北京西18:19）", InternalCode = "390000D12601"}},
                                                                        };
        public static string QueryText(string code)
        {
            TrainInfo trainInfo;
            if (TextCodeMap.TryGetValue(code, out trainInfo))
            {
                return trainInfo.Text;
            }
            throw new TrainCodeException(code);
        }

        public static string QueryInternalCode(string code)
        {
            TrainInfo trainInfo;
            if (TextCodeMap.TryGetValue(code, out trainInfo))
            {
                return trainInfo.InternalCode;
            }
            throw new TrainCodeException(code);
        }
    }
}