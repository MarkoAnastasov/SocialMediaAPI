using ShareITAPI.Models;
using ShareITAPI.ModelsDTO;
using ShareITAPI.ModelsDTO.CommentsDTO;
using ShareITAPI.ModelsDTO.LikesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Converters
{
    public static class DTOtoModel
    {
        public static Users DtoToUserRegistration(RegisterUserDto user)
        {
            var newUser = new Users()
            {
                Email = user.Email.Trim(),
                Name = user.Name.Trim(),
                Surname = user.Surname.Trim(),
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                IsPrivate = true,
                ProfilePicture = Convert.FromBase64String(InitialProfilePicture()),
                AccessToken = null,
                Password = user.Password,
                IsOnline = false
            };
            return newUser;
        }

        public static Posts PostDTOtoPost(PostDto postDto)
        {
            byte[] photoBytes = Convert.FromBase64String(postDto.PhotoUploaded);

            var post = new Posts()
            {
                PhotoUploaded = photoBytes,
                Description = postDto.Description,
                TimeUploaded = DateTime.Now,
                UserId = postDto.UserId
            };

            return post;
        }

        public static Likes AddLikeDTOtoLike(AddLikeDto like, Likes addLike)
        {
            addLike.UserId = like.UserId;
            addLike.PostId = like.PostId;
            addLike.DateCreated = DateTime.Now;

            return addLike;
        }

        public static Comments AddCommentDTOtoComment(AddCommentDto comment, Comments addComment)
        {
            addComment.UserId = comment.UserId;
            addComment.PostId = comment.PostId;
            addComment.Comment = comment.Comment;
            addComment.DateCreated = DateTime.Now;

            return addComment;
        }

        private static string InitialProfilePicture()
        {
            return "iVBORw0KGgoAAAANSUhEUgAAAZAAAAGQCAMAAAC3Ycb+AAAAA3NCSVQICAjb4U/gAAAAxlBMVEXs8PHr7/Dq7/Dp" +
                "7u/o7e/n7e7m7O7m6+3l6+zk6uzj6evi6evh6Org5+rf5+ne5ujd5ejc5efb5OfZ4+ba4+bZ4uXY4eTX4eTW4OPV3+P" +
                "U3+LT3uLR3eHS3eHQ3ODO29/P29/N2t7N2d7M2d3L2N3K19zJ19vI1tvG1drH1drF1NnE09nD0tjC0tfB0dfB0NbA0Na/z" +
                "9W+ztW9ztS8zdO6zNK7zNO5y9K3ytG4ytG2ydC0yM+1yM+0x86yxs2zxs6xxc3///860rJuAAAAQnRSTlP/////////////" +
                "/////////////////////////////////////////////////////////////////////////wBEFhAAAAAACXBIWXMAAAsS" +
                "AAALEgHS3X78AAAAHHRFWHRTb2Z0d2FyZQBBZG9iZSBGaXJld29ya3MgQ1M26LyyjAAAABV0RVh0Q3JlYXRpb24gVGltZQA0LzI" +
                "4LzE1OyW4GAAAB0hJREFUeJzt3WdX6koYhuEdUJoFLFs5IFvpCEqR3vP/f9XR5dlLPViYZIZ3Eu7rkx/zzrNwMjW/fgEAAAAAAAAA" +
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADA9g5S6extrdXudNqt2m02nTqQfqL95aTO/9Q6" +
                "47X7znrcrv05TznSz7Z/nNO7x+nK/dRq+nh3Sia7lCr0Fp+H8deiV0hKP+W+iGSq0+/TeDWtpPmZmOecPSy3iePFsnVGJIalm+ufg3izbp5" +
                "KP3GoxSpzlTheLMqH0k8dXlcj1TheDK6knzukYjUvcbyoxaSfPYwyA695PP9I0tJPHz455d7jvXlO+vlDxin6ieNFUbqEUHE8dx9vqgxJtIn" +
                "e+8/DdetR6TrCQk8ez4lEpCsJCQ3/r15VpSsJh5KuPOjZtcjry8N1efv17VJpMvEn63PpeoIuMdSZh+sO49IVBZvT1JuH6zakSwq2nO48XPcf6Zq" +
                "CLDnTH8gkIV1VgGkbgbxXk64quDJbr56rWDIX71GkayIP1+0wheJN1kwernstXVkwRZ9MBdLjJ+LF7y92ivq3+i1dWxBFHkzl4botFqvUnfpaRP/e/ES" +
                "6ugDSOOu+iXl4ZTEfu35+1mc7o6rfJvNwVxfS9QWOkVmTN6zmKjrwtI13ewPOIqpJa10o3LTkmIKagtk8XDcvXWHA1E0HwiS8kqjRl94XfeazVCS2Otb" +
                "px5TdDioyBudNXs1ZplJhbCnkDYsiKu7MB/JHusZAqZoPpCJdY6A0zAdyL11joBhcnPqrJV1jkDiP5gN5lC4ySJy2+UDaLONuL9IhEKvs4hfySCAKd" +
                "tCHPEjXGCjaj4VsakrXGCjGZ9+Zf1djdA/QK3YCqdB69PZzHMhVoffs7WfWl9I1BsqRgbNsH01S0jUGyqHm09CbhuwDUmJ8dpG5RTW3pgO5k64wYC6M" +
                "ndZ5taJPV5OYmA2ETSeKHMOdCGeoVBkeGjIsVGV2JDJjFKLKMbrPgR0O6oweoeJctLoDg/ut+wzTPfhjLpAb6doCKWlsKMKVWd6UTQVSkq4soJKGD" +
                "olM+YF4dGMmkIJ0XYFl5oKmHpfye3ZpII8Vdyn7oOm7CO/VpWsKtNhYdx5jrp3x5VLzQhWXv/ulecsc2+P80nvTX4vrAnw71Pju26MD0SClbY/W" +
                "iGUpLdKaXrXGXMmkyYmWSa0pV5Fqc6zhv9bwSLqKMDny3bM/0X9olfB56vCBKXfNor6Wq8rM8Op35blrH19JP3s4JT2ezW0kpZ88tLIebvMdcVOZ" +
                "QbGS4g7TWSkm/cwhd1xTuI5xUWXwYd5pZcth4rDC2Hw3kvnejz+TeS/P0GN3IpnKd5nMe5UMKx87Fsnk691PuvhJt55Pk4aMg6PLXLHR7g+ns9l" +
                "02G83irnLI3a2S3Mi0YNn0QjnBgEAAAAAAAAAAAAAAADAHycSPYzF4/FEIplKJROJ5z9jh2zP2r1YKnORLZTrzcfu02g4Hk8nk9lsMpmOx8PRU/e" +
                "xWS8XshfpFCdDjDtMZbLFVnc02eKMyHwy6raK2UyKraUmOPGT69v7wWKueH/War4Y3N9encT5P6ZPJHZ+0xgs1JL4aDFo3JzH2BOvwWG68DDS" +
                "8lXD9eihkOZ+Jl9S19X+UkcYfy2fqtfcseGNE883xwY+DbYaN/P0KMriV02Dn9iZNK94J1YQOdv2oK13w/IZffx24jdPWvuNryx7N3w772f" +
                "HJUPfRPjMtHgsXa/dnExD4Z4GHeaNDB38lzJN459R37RupKXrtlSmtZOuY9OymZGu3ULH9zv+Z/XevE5f8lG87Guqyr9ZmTeuN05W+1cp1A" +
                "2v6d3/k+lIh/GqQ+/+4qAk1Jdvmhe5vPTXmZEPf3nVO5NuD2HRsjU/j1fL0l7PcJ10pQPY1NnjN+DrHU5bbW+6r/fKRssCEyXbWO/nxeRJS1" +
                "52P9Pew/szzywYC35tvHdvWznL3q7+b5mTbqHdupVu8B+t7qTbaIccY5+u16m8N3Nb0Zp0W2+ntidjxIiBT0CbUd+LRCIN6XbeXmMPEokGK" +
                "A/XvQ/9EDFYeexBInXpFlZVk24xs4rS7asu1F9gz0u3rhchHrNfWjq9+731uXS7mXI0kW5bb6YhPeITtXB5cDvdcA5HAveC9aYq3XYm5KRb1" +
                "Y8QduynwntF/ZmF7ouIkZ50m/oTum6kJN2ifoVsfJgO5AjkvfWpdBvqFLF4h8m22mH6p5WVbk0dQrR/Lj6Qbkwd+uG5ayAga+g/Cc9MfF+6K" +
                "fV4km5HbQI7ifVRV7odtSEQyxCIZQjEMgRiGQKxDIFYhkAsQyCWIRDLEIhlCMQyBGIZArEMgViGQCxDIJYhEMsQiGUIxDIEYhkCsQyBWKbSDYWyd" +
                "DsCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA0O9fn8OLpIZ6n7YAAAAASUVORK5CYII=";
        }
    }
}
