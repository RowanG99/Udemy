using BMES_API_Project.Messages.DTOs.Address;
using BMES_API_Project.Messages.DTOs.Cart;
using BMES_API_Project.Messages.DTOs.Customer;
using BMES_API_Project.Messages.DTOs.Order;
using BMES_API_Project.Messages.DTOs.Product;
using BMES_API_Project.Messages.DTOs.Shared;
using BMES_API_Project.Models;
using BMES_API_Project.Models.Address;
using BMES_API_Project.Models.Cart;
using BMES_API_Project.Models.Customer;
using BMES_API_Project.Models.Order;
using BMES_API_Project.Models.Product;
using BMES_API_Project.Models.Shared;
using System.Collections.Generic;

namespace BMES_API_Project.Messages
{
    public class MessageMapper
    {
        public Brand MapToBrand(BrandDTO brandDto)
        {
            var brand = new Brand
            {
                Id = brandDto.Id,
                Name = brandDto.Name,
                Slug = brandDto.Slug,
                Description = brandDto.Description,
                MetaDescription = brandDto.MetaDescription,
                MetaKeywords = brandDto.MetaKeywords,
                BrandStatus = (BrandStatus)brandDto.BrandStatus,
                ModifiedDate = brandDto.ModifiedDate,
                isDeleted = brandDto.isDeleted
            };

            return brand;
        }

        public BrandDTO MapToBrandDto(Brand brand)
        {
            var brandDto = new BrandDTO();
            if(brand != null)
            {
                brandDto.Id = brand.Id;
                brandDto.Name = brand.Name;
                brandDto.Slug = brand.Slug;
                brandDto.Description = brand.Description;
                brandDto.MetaDescription = brand.MetaDescription;
                brandDto.MetaKeywords = brand.MetaKeywords;
                brandDto.BrandStatus = (int)brand.BrandStatus;
                brandDto.ModifiedDate = brand.ModifiedDate;
                brandDto.isDeleted = brand.isDeleted;
            }

            return brandDto;
        }
        public List<BrandDTO> MapToBrandDtos(IEnumerable<Brand> brands)
        {
            var brandDtos = new List<BrandDTO>(); 
            foreach(var brand in brands)
            {
                var brandDto = MapToBrandDto(brand);
                brandDtos.Add(brandDto); 
            }
            return brandDtos;
        }
        public Category MapToCategory(CategoryDTO categoryDto)
        {
            var category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Slug = categoryDto.Slug, 
                Description = categoryDto.Description,
                MetaDescription = categoryDto.MetaDescription,
                MetaKeywords = categoryDto.MetaKeywords, 
                CategoryStatus = (CategoryStatus)categoryDto.CategoryStatus, 
                ModifiedDate = categoryDto.ModifiedDate, 
                isDeleted = categoryDto.isDeleted
            };

            return category;
        }

        public CategoryDTO MapToCategoryDto(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                MetaDescription = category.MetaDescription,
                MetaKeywords = category.MetaKeywords,
                CategoryStatus = (int)category.CategoryStatus,
                ModifiedDate = category.ModifiedDate,
                isDeleted = category.isDeleted
            };
        }
        public List<CategoryDTO> MapToCategoryDtos(IEnumerable<Category> categories)
        {
            var categoryDtos = new List<CategoryDTO>(); 
            foreach(var category in categories)
            {
                var categoryDto = MapToCategoryDto(category);
                categoryDtos.Add(categoryDto);
            }
            return categoryDtos;
        }

        public Product MapToProduct(ProductDTO productDto)
        {
            var product = new Product
            { 
                Id = productDto.Id, 
                Name = productDto.Name,
                Slug = productDto.Slug,
                Description = productDto.Description,
                MetaDescription = productDto.MetaDescription,
                MetaKeywords = productDto.MetaKeywords, 
                SKU = productDto.SKU, 
                Model = productDto.Model, 
                Price = productDto.Price,
                SalePrice = productDto.SalePrice, 
                OldPrice = productDto.OldPrice,
                ImageUrl = productDto.ImageUrl,
                QuantityInStock = productDto.QuantityInStock,
                IsBestseller = productDto.IsBestseller, 
                CategoryId = productDto.CategoryId,
                BrandId = productDto.BrandId, 
                ProductStatus = (ProductStatus)productDto.ProductStatus, 
                CreatedDate = productDto.CreateDate,
                ModifiedDate = productDto.ModifiedDate,
                isDeleted = productDto.IsDeleted
            };

            return product;
        }

        public ProductDTO MapToProductDto(Product product)
        {
            var productDto = new ProductDTO();

            if (product != null)
            {
                productDto.Id = product.Id;
                productDto.Name = product.Name;
                productDto.Slug = product.Slug;
                productDto.Description = product.Description;
                productDto.MetaDescription = product.MetaDescription;
                productDto.MetaKeywords = product.MetaKeywords;
                productDto.SKU = product.MetaDescription;
                productDto.Model = product.MetaKeywords;
                productDto.Price = product.Price;
                productDto.SalePrice = product.SalePrice;
                productDto.OldPrice = product.OldPrice;
                productDto.ImageUrl = product.ImageUrl;
                productDto.QuantityInStock = product.QuantityInStock;
                productDto.IsBestseller = product.IsBestseller;
                productDto.CategoryId = product.CategoryId;
                productDto.BrandId = product.BrandId;
                productDto.ProductStatus = (int)product.ProductStatus;
                productDto.CreateDate = product.CreatedDate;
                productDto.ModifiedDate = product.ModifiedDate;
                productDto.IsDeleted = product.isDeleted;
            };

            return productDto;
        }

        public List<ProductDTO> MapToProductDtos(IEnumerable<Product> products)
        {
            var productDtos = new List<ProductDTO>(); 
            foreach(var product in products)
            {
                var productDto = MapToProductDto(product);
                productDtos.Add(productDto); 
            }
            return productDtos;
        }

        public CartDTO MaptoCartDto(Cart cart)
        {
            var cartDto = new CartDTO(); 
            if(cart != null)
            {
                cartDto.Id = cart.Id;
                cartDto.UniqueCartId = cart.UniqueCartId;
                cartDto.CartStatues = (int)cart.CartStatus;
                cartDto.CreateDate = cart.CreatedDate;
                cartDto.ModifiedDate = cart.ModifiedDate;
                cartDto.isDeleted = cart.isDeleted; 
            }
            return cartDto;
        }

        public Cart MapToCart(CartDTO cartDTO)
        {
            return new Cart
            {
                Id = cartDTO.Id,
                UniqueCartId = cartDTO.UniqueCartId,
                CartStatus = (CartStatus)cartDTO.CartStatues,
                CreatedDate = cartDTO.CreateDate,
                ModifiedDate = cartDTO.ModifiedDate,
                isDeleted = cartDTO.isDeleted
            };
        }

        public CartItemDTO MaptoCartItemDto(CartItem cartItem)
        {
            CartItemDTO cartItemDTO = null; 
            if(cartItem.Product != null)
            {
                var productDto = MapToProductDto(cartItem.Product);
                cartItemDTO = new CartItemDTO
                {
                    Id = cartItem.Id,
                    CartId = cartItem.CartId,
                    Product = productDto,
                    Quantity = cartItem.Quantity
                }; 
            }
            return cartItemDTO; 
        }

        public CartItem MaptoCartItem(CartItemDTO cartItemDTO)
        {
            return new CartItem
            {
                CartId = cartItemDTO.Id,
                ProductId = cartItemDTO.Product.Id,
                Quantity = cartItemDTO.Quantity
            }; 
        }

        public List<CartItemDTO> MaptoCartItemDto(IEnumerable<CartItem> cartItems)
        {
            var cartItemDtos = new List<CartItemDTO>(); 
            foreach(var cartIem in cartItems)
            {
                var cartItemDto = MaptoCartItemDto(cartIem);
                cartItemDtos.Add(cartItemDto); 
            }
            return cartItemDtos; 
        }

        public AddressDTO MapToAddressDto(Address address)
        {
            var addressDto = new AddressDTO
            {
                Id = address.Id, 
                Name = address.Name, 
                AddressLine1 = address.AddressLine1, 
                AddressLine2 = address.AddressLine2, 
                City = address.City, 
                Country = address.Country, 
                State = address.State, 
                ZipCode = address.ZipCode, 
                CreatedDate = address.CreatedDate, 
                ModifiedDate = address.ModifiedDate, 
                isDeleted = address.isDeleted
            };
            return addressDto; 
        }

        public Address MaptoAddress(AddressDTO addressDTO)
        {
            return new Address
            {
                Id = addressDTO.Id, 
                Name = addressDTO.Name,
                AddressLine1 = addressDTO.AddressLine1,
                AddressLine2 = addressDTO.AddressLine2,
                City = addressDTO.City,
                Country = addressDTO.Country,
                State = addressDTO.State,
                ZipCode = addressDTO.ZipCode,
                CreatedDate = addressDTO.CreatedDate,
                ModifiedDate = addressDTO.ModifiedDate,
                isDeleted = addressDTO.isDeleted
            };
        }

        public CustomerDTO MapToCustomerDto(Customer customer)
        {
            var customerDto = new CustomerDTO
            {
                Id = customer.Id,
                FirstName = customer.Person.FirstName, 
                MiddleName = customer.Person.MiddleName, 
                LastName = customer.Person.LastName, 
                EmailAddress = customer.Person.EmailAddress,
                PhoneNumber = customer.Person.PhoneNumber, 
                Sex = (int)customer.Person.Sex, 
                DateOfBirth = customer.Person.DateOfBirth,
                CreatedDate = customer.Person.CreatedDate, 
                ModifiedDate = customer.Person.ModifiedDate, 
                isDeleted = customer.Person.isDeleted
            };
            return customerDto; 
        }

        public Customer MapToCustomer(CustomerDTO customerDTO)
        {
            var person = new Person
            {
                Id = customerDTO.Id,
                FirstName = customerDTO.FirstName,
                MiddleName = customerDTO.MiddleName,
                LastName = customerDTO.LastName,
                EmailAddress = customerDTO.EmailAddress,
                PhoneNumber = customerDTO.PhoneNumber,
                Sex = (Sex)customerDTO.Sex,
                DateOfBirth = customerDTO.DateOfBirth, 
                CreatedDate = customerDTO.CreatedDate, 
                ModifiedDate = customerDTO.ModifiedDate,
                isDeleted = customerDTO.isDeleted
            };

            return new Customer
            {
                Id = customerDTO.Id,
                Person = person
            }; 
        }

        public PersonDTO MapTpPersonDto(Person person)
        {
            var personDto = new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                EmailAddress = person.EmailAddress,
                PhoneNumber = person.PhoneNumber,
                Sex = (int)person.Sex,
                DateOfBirth = person.DateOfBirth,
                CreatedDate = person.CreatedDate,
                ModifiedDate = person.ModifiedDate,
                isDeleted = person.isDeleted
            };

            return personDto; 
        }

        public Person MapToPerson(PersonDTO personDTO)
        {
            return new Person
            {
                Id = personDTO.Id,
                FirstName = personDTO.FirstName,
                MiddleName = personDTO.MiddleName,
                LastName = personDTO.LastName,
                EmailAddress = personDTO.EmailAddress,
                PhoneNumber = personDTO.PhoneNumber,
                Sex = (Sex)personDTO.Sex,
                DateOfBirth = personDTO.DateOfBirth,
                CreatedDate = personDTO.CreatedDate,
                ModifiedDate = personDTO.ModifiedDate,
                isDeleted = personDTO.isDeleted
            };
        }

        public Order MapToOrder(OrderDTO orderDTO)
        {
            return new Order
            {
                Id = orderDTO.Id, 
                OrderTotal = orderDTO.OrderTotal, 
                OrderItemTotal = orderDTO.OrderItemTotal, 
                ShippingCharge = orderDTO.ShippingCharge, 
                CustomerId = orderDTO.CustomerId, 
                OrderStatus = (OrderStatus)orderDTO.OrderStatus, 
                CreatedDate = orderDTO.CreatedDate, 
                ModifiedDate = orderDTO.ModifiedDate, 
                isDeleted = orderDTO.isDeleted
            };
        }

        public OrderDTO MapToOrderDto(Order order)
        {
            var orderDto = new OrderDTO
            {
                Id = order.Id,
                OrderTotal = order.OrderTotal,
                OrderItemTotal = order.OrderItemTotal,
                ShippingCharge = order.ShippingCharge,
                CustomerId = order.CustomerId,
                OrderStatus = (int)order.OrderStatus,
                CreatedDate = order.CreatedDate,
                ModifiedDate = order.ModifiedDate,
                isDeleted = order.isDeleted
            };

            return orderDto;
        }

        public OrderItemDTO MapToOrderItemDto(OrderItem orderItem)
        {
            OrderItemDTO orderItemDTO = null; 

            if(orderItem.Product != null)
            {
                var productDto = MapToProductDto(orderItem.Product);
                orderItemDTO = new OrderItemDTO
                {
                    Id = orderItem.Id,
                    OrderId = orderItem.OrderId,
                    Product = productDto,
                    Quantity = orderItem.Quantity
                };
            }
            return orderItemDTO;
        }

        public OrderItem MaptToOrderItem(OrderItemDTO orderItemDTO)
        {
            return new OrderItem
            {
                OrderId = orderItemDTO.OrderId,
                ProductId = orderItemDTO.ProductId,
                Quantity = orderItemDTO.Quantity
            }; 
        }

        public List<OrderDTO> MapToOrderDtos(IEnumerable<Order> orders)
        {
            var orderDtos = new List<OrderDTO>();
            foreach (var order in orders)
            {
                var orderDto = MapToOrderDto(order);
                orderDtos.Add(orderDto);
            }
            return orderDtos;
        }
    }
}
