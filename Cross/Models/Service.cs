using System;
using System.Collections.Generic;

namespace IntelligentApp.Models
{
    public class Service
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string Icon { get; set; }
        public Type Type { get; set; }

        public static IReadOnlyCollection<Service> ListAll()
        {
            var info = "Ao carregar dados para esta demonstração, você concorda que a Microsoft pode armazená-los e usá-los para aprimorar os serviços da Microsoft, incluindo esta API. Para ajudar a proteger sua privacidade, realizamos etapas para remover a identificação dos dados e mantê-los seguros. Não publicaremos seus dados nem permitiremos que outras pessoas os utilizem.";

            var service = new List<Service>();
            service.Add(new Service
            {
                Name = "Face API",
                Icon = "face.png",
                Detail = "Detecte, Identifique, Analise, Organize e Marque rostos em fotos",
                Description = "Detecte um ou mais rostos em uma imagem e receba retângulos de rostos do local em que eles estão na imagem, juntamente com os atributos de rostos que contêm previsões baseadas em aprendizado de máquina de características faciais.\n\nAs características dos atributos faciais disponíveis são: Idade, Emoções, Gênero, Pose, Sorriso e Pelos Faciais, juntamente com 27 pontos de referência para cada rosto na imagem.",
                Info = info,
                Type = typeof(CognitiveServices.Face)
            });
            service.Add(new Service
            {
                Name = "Emotion API",
                Icon = "emoticon.png",
                Detail = "Personalize a experiência do usuário com o reconhecimento de Emoções",
                Description = "A API de Detecção de Emoções recebe a expressão facial em uma imagem como uma entrada e retorna a confiança entre um conjunto de emoções para cada face na imagem, além da caixa delimitadora para a face, usando a API de Detecção Facial.\n\nSe um usuário já chamou a API de Detecção Facial, ele pode enviar o retângulo da face como uma entrada opcional.\n\nAs emoções detectadas são raiva, desdém, aversão, medo, felicidade, neutralidade, tristeza e surpresa.\n\nEntende-se que essas emoções comunicam-se de forma intercultural e universal com expressões faciais específicas.",
                Info = info,
                Type = typeof(CognitiveServices.Emotion)
            });
            service.Add(new Service
            {
                Name = "Computer Vision API",
                Icon = "visions.png",
                Detail = "Extraia informações de imagens",
                Description = "Este recurso retorna informações sobre o conteúdo visual encontrado em uma imagem.\n\nUse marcação, descrições e modelos específicos de domínio para identificar o conteúdo o os rotule com confiança.\n\nAplique as configurações de tipo/adulto para habilitar as restrições de conteúdo somente para adultos.\n\nIdentifique tipos de imagem e esquemas de cores em fotos.",
                Info = info,
                Type = typeof(CognitiveServices.Vision)
            });
            service.Add(new Service
            {
                Name = "OCR",
                Icon = "ocr.png",
                Detail = "Extraia textos de imagens",
                Description = "O OCR (reconhecimento óptico de caracteres) detecta textos em uma imagem e extrai as palavras reconhecidas para um fluxo de caracteres legíveis por computador.\n\nAnalise imagens para detectar texto inserido, gerar fluxos de caractere e habilitar pesquisa.\n\nTire fotos de texto em vez de copiá-lo para economizar tempo e esforço.",
                Info = info,
                Type = typeof(CognitiveServices.OCR)
            });
            service.Add(new Service
            {
                Name = "Custom Vision",
                Icon = "custom_visions.png",
                Detail = "Inteligência Visual de uma forma fácil",
                Description = "Personalize facilmente seus próprios modelos visuais computacionais modernos para seu caso de uso exclusivo.\n\nBasta carregar algumas imagens rotuladas e deixar o Serviço Personalizado de Visão fazer o trabalho pesado.",
                Info = info,
                Type = typeof(CognitiveServices.CustomVision)
            });

            return service;
        }
    }
}
