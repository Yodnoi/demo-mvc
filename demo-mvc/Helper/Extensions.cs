using demo_mvc.ViewModels;

namespace demo_mvc
{
    public static class Extensions
    {
        public static DataResult DataResult(this object value, Enum status)
        {
            return new DataResult
            {
                status = (int)(object)status,
            };
        }
        public static DataResult<T> DataResult<T>(this object value, Enum status, T data)
        {
            return new DataResult<T>
            {
                status = (int)(object)status,
                data = data,
            };
        }

    }
}
