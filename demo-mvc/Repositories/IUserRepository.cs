using demo_mvc.Context;
using demo_mvc.Models;
using demo_mvc.ViewModels;
using demo_mvc.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace demo_mvc.Repositories
{
    public interface IUserRepository
    {
        DataResult<List<IndexViewModel>> Index();
        DataResult<GetViewModel> Get(string id);
        DataResult InsertOrUpdate(InsertOrUpdateParam param);
        DataResult Delete(string id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DemoMVCDbContext context;
        public UserRepository(DemoMVCDbContext context)
        {
            this.context = context;
        }
        public DataResult<List<IndexViewModel>> Index()
        {
            try
            {
                IQueryable<IndexViewModel> query = context.users
                                                    .Where(w => w.is_enable)
                                                    .OrderBy(o => o.username)
                                                    .Select(s => new IndexViewModel
                                                    {
                                                        user_id = s.user_id,
                                                        first_name = s.first_name,
                                                        last_name = s.last_name,
                                                        username = s.username,
                                                        phone_number = s.phone_number,
                                                        date_create = s.date_create,
                                                        date_update = s.date_update,
                                                        role_id = s.role_id,
                                                    })
                                                    .AsNoTracking();

                return this.DataResult(StatusCode.Success, query.ToList());
            }
            catch (Exception ex)
            {
                return this.DataResult(StatusCode.Fail, new List<IndexViewModel>());
            }
        }
        public DataResult<GetViewModel> Get(string id)
        {
            var item = context.users
                                .AsNoTracking()
                                .Single(w => w.is_enable && w.user_id == id);
            var result = new GetViewModel
            {
                user_id = item.user_id,
                first_name = item.first_name,
                last_name = item.last_name,
                username = item.username,
                phone_number = item.phone_number,
                role_id = item.role_id,
            };
            return this.DataResult(StatusCode.Success, result);
        }
        public DataResult InsertOrUpdate(InsertOrUpdateParam param)
        {
            using (var Transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var item = new user();
                    IQueryable<user> item_all = context.users.Where(w => w.is_enable && w.username.ToLower() == param.username.ToLower());
                    if (string.IsNullOrEmpty(param.user_id))
                    {
                        if (item_all.Any())
                            return this.DataResult(StatusCode.Fail);

                        item = new user();
                        item.user_id = Guid.NewGuid().ToString();
                        item.date_create = DateTime.UtcNow;
                        item.is_enable = true;

                        item.username = param.username;
                        item.pwd = "PWD"; //TODO:  GEN AND SEND EMAIL
                        // item.password_hash = BCryptNet.HashPassword("PWD");
                        context.users.Add(item);
                    }
                    else
                    {
                        if (item_all.Any(w => w.user_id != param.user_id))
                            return this.DataResult(StatusCode.Fail);

                        item = context.users.Single(w => w.is_enable && w.user_id == param.user_id);
                        item.date_update = DateTime.UtcNow;
                    }
                    item.first_name = param.first_name;
                    item.last_name = param.last_name;
                    item.phone_number = param.phone_number;
                    item.role_id = param.role_id;

                    context.SaveChanges();
                    Transaction.Commit();
                    return this.DataResult(StatusCode.Success);
                }
                catch (Exception ex)
                {
                    Transaction.Rollback();
                    return this.DataResult(StatusCode.Fail);
                }
            }
        }
        public DataResult Delete(string id)
        {
            using (var Transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var item = context.users.SingleOrDefault(w => w.is_enable && w.user_id == id);
                    if (item == null)
                        throw new Exception("user not found");

                    item.is_enable = false;
                    item.date_update = DateTime.UtcNow;
                    context.SaveChanges();
                    Transaction.Commit();
                    return this.DataResult(StatusCode.Success);
                }
                catch (Exception ex)
                {
                    Transaction.Rollback();
                    return this.DataResult(StatusCode.Fail);
                }
            }
        }
    }
}
