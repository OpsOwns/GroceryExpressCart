using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;
using System;
using System.Collections.Generic;

namespace GroceryExpressCart.Core.ValueObject
{
    public class ImageDish : ValueObject<ImageDish>
    {
        public static ImageDish ImageDishEmpty => new ImageDish(nameof(Parameters.EMPTY));
        public string ImageDishValue { get; protected set; }
        protected ImageDish() { }
        private ImageDish(string value) => ImageDishValue = value;
        public static Result<ImageDish> Create(string imageDish)
        {
            if (imageDish.IsEmpty() && Uri.IsWellFormedUriString(imageDish, UriKind.RelativeOrAbsolute))
                return Result.FailEmpty(nameof(Parameters.INVALID_LOGIN), ImageDishEmpty);
            return Result.Ok(new ImageDish(imageDish));
        }
        public override int GetHashCode() =>
            HashCodeGenerator.Of(ImageDishValue);
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ImageDishValue;
        }
    }
}
