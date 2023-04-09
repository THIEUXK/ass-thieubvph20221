﻿using ass_thieubvph20221.Models;
using Newtonsoft.Json;

namespace ass_thieubvph20221.Services
{
    public class SessionServices
    {
        // Đưa dữ liệu vào Session dưới dạng Json data
        public static void SetObjToJson(ISession session, string key, object value)
        {
            // Obj value là dữ liệu bạn muốn thêm vào Session
            // Chuyển đổi dữ liệu đó sang dạng JsonString
            var jsonString = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonString);
        }
        // Lấy và đưa dữ liệu từ session về dạng List<obj>
        public static List<giay> GetObjFromSession(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<giay>>(data);
                return listObj;
            }
            else return new List<giay>();
        }

        public static bool CheckProductInCart(Guid id, List<giay> cartProducts)
        {
            return cartProducts.Any(p => p.id == id); // Kiểm tra xem có tồn tại sp đó trong GH chưa
        }
    }
}
