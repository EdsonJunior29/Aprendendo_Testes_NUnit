
namespace TestesUnitários.Fundamentos
{
    public class CustomerController
    {
        public ActionResult GetCustomer(int id)
        {
            if (id == 0)
            {
                return new NotFound();
            }

            return new OK();
        }
    }

    public class ActionResult { }

    public class NotFound : ActionResult { }

    public class OK : ActionResult { }
}
