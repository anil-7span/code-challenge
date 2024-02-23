using Code.Challenge.Entities;

public class ProductManager
{
    int? minVal = null;
    readonly Dictionary<string, int> availableProducts = new();

    public static void Main(string[] args)
    {
        var program = new ProductManager();
        program.RunProgram(string.Empty, new List<Products>(), new List<ProductMappings>());
    }

    public int RunProgram(string bundleName, List<Products> products, List<ProductMappings> mappings)
    {
        var data = products.FirstOrDefault(x => x.Name.ToLower() == bundleName.ToLower());
        if (data != null)
        { 
            List<Products> nestedChildProducts = GetNestedChildProducts(data.Id, products, mappings,  null);
        }
        return Convert.ToInt32(minVal);
    }

    public List<Products> GetNestedChildProducts(int parentId, List<Products> products, List<ProductMappings> mappings, int? parentRequiredQty = null)
    {
        List<Products> result = new List<Products>();

        try
        {
            var directChildMappings = mappings.Where(m => m.ParentProductId == parentId).ToList();

            foreach (var mapping in directChildMappings)
            {
                var childProduct = products.FirstOrDefault(p => p.Id == mapping.ChildProductId);
                if (childProduct != null)
                {
                    result.Add(childProduct);
                    if (childProduct.IsAssembled)
                    {
                        var nestedChildProducts = GetNestedChildProducts(childProduct.Id, products, mappings, mapping.RequiredQty);
                        result.AddRange(nestedChildProducts);
                    }
                    else
                    {
                        int productQty = (childProduct.Qty ?? 0) / mapping.RequiredQty;
                        if (parentRequiredQty is not null && parentRequiredQty > 0)
                            productQty = productQty / parentRequiredQty.Value;

                        availableProducts.Add(childProduct.Name, productQty);

                        if (minVal is null || productQty < minVal)
                            minVal = productQty;
                    }
                }
            }
        }
        catch 
        {
            return new List<Products>();
        }
        return result;
    }
}
