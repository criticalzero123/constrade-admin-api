using ConstradeApi_Admin.Entity;
using ConstradeApi_Admin.Model.MBoostProduct;
using ConstradeApi_Admin.Model.MCommunity;
using ConstradeApi_Admin.Model.MCommunity.MCommunityPost;
using ConstradeApi_Admin.Model.MCommunity.MCommunityPostComment;
using ConstradeApi_Admin.Model.MProduct;
using ConstradeApi_Admin.Model.MReport;
using ConstradeApi_Admin.Model.MSubcription;
using ConstradeApi_Admin.Model.MSystemFeedback;
using ConstradeApi_Admin.Model.MTransaction;
using ConstradeApi_Admin.Model.MUser;
using ConstradeApi_Admin.Model.MWallet;
using ConstradeApi_Admin.VerificationEntity;
using ConstradeApi_Admin.VerificationModel.MValidIdRequest;

namespace ConstradeApi_Admin.Services.EntityToModel
{
    public static class EntityCastService
    {
        public static PersonModel ToModel(this Person person)
        {
            return new PersonModel()
            {
                PersonId = person.Person_id,
                AddressReferenceId = person.AddressRef_id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Birthdate = person.Birthdate,
                PhoneNumber = person.PhoneNumber,
                Gender = person.Gender,
            };
        }
        public static UserModel ToModel(this User user)
        {
            return new UserModel()
            {
                UserId = user.UserId,
                FirebaseId = user.FirebaseId,
                PersonRefId = user.PersonRefId,
                UserType = user.UserType,
                AuthProviderType = user.AuthProviderType,
                UserStatus = user.UserStatus,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                LastActiveAt = user.LastActiveAt,
                CountPost = user.CountPost,
                DateCreated = user.DateCreated,
                
            };
        }
        public static ProductModel ToModel(this Product product)
        {
            return new ProductModel()
            {
                ProductId = product.ProductId,
                PosterUserId = product.PosterUserId,
                Title = product.Title,
                Description = product.Description,
                ModelNumber = product.ModelNumber,
                SerialNumber = product.SerialNumber,
                GameGenre = product.GameGenre,
                Platform = product.Platform,
                ThumbnailUrl = product.ThumbnailUrl,
                Cash = product.Cash,
                Item = product.Item,
                DateCreated = product.DateCreated,
                CountFavorite = product.CountFavorite,
                Condition = product.Condition,
                PreferTrade = product.PreferTrade,
                IsMeetup = product.IsMeetup,
                IsDeliver = product.IsDeliver,
                Location = product.Location,
                ProductStatus = product.ProductStatus,
                HasReceipts = product.HasReceipts,
                HasWarranty = product.HasWarranty,
                IsGenerated = product.IsGenerated,
                Value = product.Value,
            };
        }
        public static TransactionModel ToModel(this Transaction transaction)
        {
            return new TransactionModel
            {
                TransactionId = transaction.TransactionId,
                ProductId = transaction.ProductId,
                BuyerUserId = transaction.BuyerUserId,
                SellerUserId = transaction.SellerUserId,
                InAppTransaction = transaction.InAppTransaction,
                GetWanted = transaction.GetWanted,
                IsReviewed = transaction.IsReviewed,
                DateTransaction = transaction.DateTransaction,
            };
        }
        public static UserReviewModel ToModel(this Review review) 
        {
            return new UserReviewModel
            {
                ReviewId = review.ReviewId,
                TransactionRefId = review.TransactionRefId,
                Rate = review.Rate,
                Description = review.Description,
                DateCreated = review.DateCreated,
            };
        }
        public static WalletModel ToModel(this Wallet wallet)
        {
            return new WalletModel()
            {
                WalletId = wallet.WalletId,
                UserId = wallet.UserId,
                Balance = wallet.Balance,
            };
        }

        public static SubscriptionHistoryModel ToModel(this SubscriptionHistory subscription)
        {
            return new SubscriptionHistoryModel
            {
                SubscriptionHistoryId = subscription.SubscriptionHistoryId,
                SubscriptionId = subscription.SubscriptionId,
                DateUpdate = subscription.DateUpdate,
                PreviousSubscriptionType = subscription.PreviousSubscriptionType,
                NewSubscriptionType = subscription.NewSubscriptionType,
                PreviousDateStart = subscription.PreviousDateStart,
                NewDateStart = subscription.NewDateStart,
                PreviousDateEnd = subscription.PreviousDateEnd,
                NewDateEnd = subscription.NewDateEnd,
                PreviousAmount = subscription.PreviousAmount,
                NewAmount = subscription.NewAmount,
            };
        }
        public static SendMoneyTransactionModel ToModel(this SendMoneyTransaction transac)
        {
            return new SendMoneyTransactionModel()
            {
                SendMoneyTransactionId = transac.SendMoneyTransactionId,
                SenderWalletId = transac.SenderWalletId,
                ReceiverWalletId = transac.ReceiverWalletId,
                Amount = transac.Amount,
                Date = transac.DateSend,
            };
        }
        public static SubscriptionModel ToModel(this Subscription subscription)
        {
            return new SubscriptionModel
            {
                SubscriptionId = subscription.SubscriptionId,
                UserId = subscription.UserId,
                SubscriptionType = subscription.SubscriptionType,
                DateStart = subscription.DateStart,
                DateEnd = subscription.DateEnd,
                Amount = subscription.Amount,
            };
        }

        public static ReportModel ToModel(this Report report)
        {
            return new ReportModel
            {
                ReportId = report.ReportId,
                IdReported= report.IdReported,
                ReportedBy = report.ReportedBy,
                ReportType = report.ReportType,
                Description = report.Description,
                Status = report.Status,
                DateSubmitted = report.DateSubmitted,
            };
        }
        public static SystemFeedbackModel ToModel(this SystemFeedback systemFeedback)
        {
            return new SystemFeedbackModel
            {
                SystemFeedbackId = systemFeedback.SystemFeedbackId,
                UserId = systemFeedback.UserId,
                ReportType = systemFeedback.ReportType,
                Title = systemFeedback.Title,
                Status = systemFeedback.Status,
                Description = systemFeedback.Description,
                DateSubmitted = systemFeedback.DateSubmitted,
            };
        }
        public static CommunityModel ToModel(this Community community)
        {
            return new CommunityModel
            {
                CommunityId = community.CommunityId,
                OwnerUserId = community.OwnerUserId,
                Name = community.Name,
                Description = community.Description,
                ImageUrl = community.ImageUrl,
                Visibility = community.Visibility,
                DateCreated = community.DateCreated,
                TotalMembers = community.TotalMembers,
            };
        }
        public static CommunityPostModel ToModel(this CommunityPost info)
        {
            return new CommunityPostModel
            {
                CommunityPostId = info.CommunityPostId,
                CommunityId = info.CommunityId,
                PosterUserId = info.PosterUserId,
                Description = info.Description,
                CreatedDate = info.CreatedDate,
                Like = info.Like
            };
        }
        public static CommunityPostCommentModel ToModel(this CommunityPostComment info)
        {
            return new CommunityPostCommentModel
            {
                CommunityPostCommentId = info.CommunityPostCommentId,
                CommunityPostId = info.CommunityPostId,
                CommentedByUser = info.CommentedByUser,
                Comment = info.Comment,
                DateCommented = info.DateCommented,
            };
        }

        public static ValidIdRequestModel ToModel(this ValidIdRequest info)
        {
            return new ValidIdRequestModel
            {
                ValidIdRequestId = info.ValidIdRequestId,
                ValidIdNumber = info.ValidIdNumber,
                UserId = info.UserId,
                UserName = info.UserName,
                ValidationType = info.ValidationType,
                RequestDate = info.RequestDate,
                Status  = info.Status,
            };
        }

        public static BoostProductModel ToModel(this BoostProduct info)
        {
            return new BoostProductModel
            {
                BoostProductId = info.BoostProductId,
                ProductId = info.ProductId,
                DaysBoosted = info.DaysBoosted,
                Status = info.Status,
                DateTimeExpired= info.DateTimeExpired,
                DateBoosted = info.DateBoosted,
            };
        } 

    }
}
