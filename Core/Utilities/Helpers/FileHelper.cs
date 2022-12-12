﻿using System;
using System.IO;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private static readonly string _currentDirectory = Environment.CurrentDirectory + "/wwwroot";
        private static readonly string _folderName = "/images/";

        public static IResult Upload(IFormFile file)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null) return new ErrorResult(fileExists.Message);
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();
            if (typeValid.Message != null) return new ErrorResult(typeValid.Message);
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type));
        }

        public static IResult Update(IFormFile file, string imagePath)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null) return new ErrorResult(fileExists.Message);

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();
            if (typeValid.Message != null) return new ErrorResult(typeValid.Message);
            DeleteOldImageFile((_currentDirectory + imagePath));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type));
        }

        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessResult();
        }

        private static IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0) return new SuccessResult();
            return new ErrorResult("There is no such file!");
        }

        private static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".jpg" && type != ".png")
                return new ErrorResult("Wrong file extension! Should be png, jpg or jpeg.");
            return new SuccessResult();
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }

        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (var fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\"))) File.Delete(directory.Replace("/", "\\"));
        }
    }
}