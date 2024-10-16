namespace TopInterview150;

internal class _0238_ProductOfArrayExceptSelf
{
    public void Launch()
    {
        Execute([1, 2, 3, 4]);
        Execute([-1, 1, 0, -3, 3]);
    }

    private void Execute(int[] nums)
    {
        ProductExceptSelfV2(nums);
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        var fromLeftToRight = new int[nums.Length];
        fromLeftToRight[0] = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            fromLeftToRight[i] = nums[i - 1] * fromLeftToRight[i - 1];
        }

        var fromRightToLeft = new int[nums.Length];
        fromRightToLeft[nums.Length - 1] = 1;
        for (var i = nums.Length - 2; i >= 0; i--)
        {
            fromRightToLeft[i] = nums[i + 1] * fromRightToLeft[i + 1];
        }

        for (var i = 0; i < nums.Length; i++)
        {
            fromLeftToRight[i] *= fromRightToLeft[i];
        }

        return fromLeftToRight;
    }

    public int[] ProductExceptSelfV2(int[] nums)
    {
        var lenght = nums.Length;

        var result = new int[lenght];
        result[0] = 1;
        for (var i = 1; i < lenght; i++)
        {
            result[i] = nums[i - 1] * result[i - 1];
        }
        //result[i] equals product[0; i]

        var product = 1;
        for (var i = lenght - 2; i >= 0; i--)
        {
            //product equals product[i+1; nums.Length - 1]
            product *= nums[i + 1];
            result[i] *= product;
        }

        return result;
    }
}
