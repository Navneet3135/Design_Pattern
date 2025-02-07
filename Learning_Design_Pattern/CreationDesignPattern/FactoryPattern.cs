using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Design_Pattern.CreationDesignPattern
{
    
        public interface IAzure
        {
            void Create();
        }

        public class AzureCognitiveService : IAzure
        {
            public void Create()
            {
                Console.WriteLine($"Creating object for Azure Cognitive Service");
            }
        }

        public class AzureAIService : IAzure
        {
            public void Create()
            {
                Console.WriteLine($"Creating object for Azure AI Service");
            }
        }

        public class AzureTranslationService : IAzure
        {
            public void Create()
            {
                Console.WriteLine($"Creating object for Azure Translation Service");
            }
        }

       public class AzureFactory
       {
        public static IAzure GetAzureObject(string azureObject)
         {
            if(azureObject.Equals("AzureCognitiveService", StringComparison.OrdinalIgnoreCase))
                return new AzureCognitiveService();
            if (azureObject.Equals("AzureAIService", StringComparison.OrdinalIgnoreCase))
                return new AzureAIService();
            if (azureObject.Equals("AzureTranslationService", StringComparison.OrdinalIgnoreCase))
                return new AzureTranslationService();
            else
                throw new ArgumentException("No Azure Found");
          }
       
       }

      public class MainMethodFactory
      {
        public static void Initialize()
        {
            IAzure azure = AzureFactory.GetAzureObject("AzureCognitiveService");
            azure.Create(); 
        }
      }

    }

    

