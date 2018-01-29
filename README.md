# IntelligentApp

| Android                                                                                                                                  | iOS                                                                                                                                      | UWP                                                                                                                                      |
| ---------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| [![Build status](https://build.appcenter.ms/v0.1/apps/fcc1422e-7ac9-4fd1-b0cc-90f77149e098/branches/master/badge)](https://appcenter.ms) | [![Build status](https://build.appcenter.ms/v0.1/apps/7905fabb-f243-446d-89f4-9fce5c3988e0/branches/master/badge)](https://appcenter.ms) | [![Build status](https://build.appcenter.ms/v0.1/apps/fcc1422e-7ac9-4fd1-b0cc-90f77149e098/branches/master/badge)](https://appcenter.ms) |


App Xamarin Forms demonstrando alguns serviços cognitivos da Microsoft.

## Serviços Cognitivos

Turbine aplicativos, sites e bots com algoritmos para que eles vejam, ouçam, falem, entendam e interpretem as necessidades do usuário por meio de métodos naturais de comunicação. Transforme os seus negócios com inteligência artificial hoje mesmo

Para saber mais acesse [https://microsoft.com/cognitive](https://microsoft.com/cognitive)

**_Todas as informações foram obtidas no site da Microsoft_**

---

### [Face API](https://azure.microsoft.com/en-us/services/cognitive-services/face/)

Detecte um ou mais rostos em uma imagem e receba retângulos de rostos do local em que eles estão na imagem, juntamente com os atributos de rostos que contêm previsões baseadas em aprendizado de máquina de características faciais. As características dos atributos faciais disponíveis são: Idade, Emoções, Gênero, Pose, Sorriso e Pelos Faciais, juntamente com 27 pontos de referência para cada rosto na imagem.

[Documentação](https://docs.microsoft.com/en-us/azure/cognitive-services/face/overview)

[API Reference](https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236)

[SDKs](https://docs.microsoft.com/en-us/azure/cognitive-services/face/)

---

### [Emotion API *preview](https://azure.microsoft.com/en-us/services/cognitive-services/emotion/)

A API de Detecção de Emoções recebe a expressão facial em uma imagem como uma entrada e retorna a confiança entre um conjunto de emoções para cada face na imagem, além da caixa delimitadora para a face, usando a API de Detecção Facial. Se um usuário já chamou a API de Detecção Facial, ele pode enviar o retângulo da face como uma entrada opcional.

As emoções detectadas são raiva, desdém, aversão, medo, felicidade, neutralidade, tristeza e surpresa. Entende-se que essas emoções comunicam-se de forma intercultural e universal com expressões faciais específicas.

[Documentação e SDKs](https://docs.microsoft.com/en-us/azure/cognitive-services/emotion/home)

[API Reference](https://westus.dev.cognitive.microsoft.com/docs/services/5639d931ca73072154c1ce89/operations/563b31ea778daf121cc3a5fa)

---

### [Computer Vision API](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/)

Este recurso retorna informações sobre o conteúdo visual encontrado em uma imagem. Use marcação, descrições e modelos específicos de domínio para identificar o conteúdo o os rotule com confiança. Aplique as configurações de tipo/adulto para habilitar as restrições de conteúdo somente para adultos. Identifique tipos de imagem e esquemas de cores em fotos.

[Documentação](https://docs.microsoft.com/en-us/azure/cognitive-services/computer-vision/home)

[API Reference](https://westus.dev.cognitive.microsoft.com/docs/services/56f91f2d778daf23d8ec6739/operations/56f91f2e778daf14a499e1fa)

[SDKs](https://docs.microsoft.com/en-us/azure/cognitive-services/computer-vision/)

---

### [OCR](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/)

O OCR (reconhecimento óptico de caracteres) detecta textos em uma imagem e extrai as palavras reconhecidas para um fluxo de caracteres legíveis por computador. Analise imagens para detectar texto inserido, gerar fluxos de caractere e habilitar pesquisa. Tire fotos de texto em vez de copiá-lo para economizar tempo e esforço.
Essa funcionalidade faz parte da api de Visão Computacional.

[Documentação](https://docs.microsoft.com/en-us/azure/cognitive-services/computer-vision/home)

[API Reference](https://westus.dev.cognitive.microsoft.com/docs/services/56f91f2d778daf23d8ec6739/operations/56f91f2e778daf14a499e1fa)

[SDKs](https://docs.microsoft.com/en-us/azure/cognitive-services/computer-vision/)

---

### [Custom Vision *preview](https://www.customvision.ai/)

Personalize facilmente seus próprios modelos de Visão Computacional que se encaixam perfeitamente com seu caso de uso exclusivo. Basta trazer alguns exemplos de imagens classificadas e deixar o serviço Visão Personalizada fazer o trabalho pesado.

[Documentação](https://docs.microsoft.com/en-us/azure/cognitive-services/custom-vision-service/home)

*API Reference* e *SDKs* ainda não disponíveis. Você vai obter informações sobre como consumir esse REST API dentro do [próprio site](https://www.customvision.ai/) com o serviço criado.

---

## Como testar

Este App foi desenvolvido utilizando a tecnologia Xamarin.

Se você ainda não a conhece recomendo a playlist do youtube [**Xamarin para Iniciantes**](http://bit.ly/XamarinParaIniciantes)

[Clique aqui para se inscrever no meu canal](https://www.youtube.com/angelobelchior?sub_confirmation=1)

---

## Chaves de Segurança para os Serviços

Você precisará informar as chaves de segurança para poder utilizar os serviços.
Na classe [Constants.cs](https://github.com/angelobelchior/IntelligentApp/blob/master/IntelligentApp/CognitiveServices/Constants.cs) você vai encontrar 5 constantes:

```csharp
    public class Constants
    {
        public const string EmotionApiEndpoint = "";
        public const string EmotionApiKey = "";

        public const string FaceApiEndpoint = "";
        public const string FaceApiKey = "";

        public const string VisionApiEndpoint = "";
        public const string VisionApiKey = "";
        
        public const string CustomVisionsApiKey = "";
        public const string CustomVisionsApiEndpoint = "";
    }
```

* **EmotionApiKey** e **EmotionApiEndpoint**: [Clique Aqui para obter uma chave e o Endpoint](https://azure.microsoft.com/pt-br/try/cognitive-services/?api=emotion-api)
* **FaceApiKey** e **FaceApiEndpoint**: [Clique Aqui para obter uma chave e o Endpoint](https://azure.microsoft.com/pt-br/try/cognitive-services/?api=face-api)
* **VisionApiKey** e **VisionApiEndpoint**: [Clique Aqui para obter uma chave e o Endpoint](https://azure.microsoft.com/pt-br/try/cognitive-services/?api=computer-vision)
* **CustomVisionsApiKey** e **CustomVisionsApiEndpoint**: Esse serviço ainda está em _preview_. Para obter as chaves e o endpoint de testes é necessário criar uma conta em [https://www.customvision.ai/](https://www.customvision.ai/)

**Você vai precisar ter uma conta no Microsoft Azure. Você pode criar gratuitamente.**

Para maiores informações:

* [Crie sua conta gratuita do Azure hoje mesmo](https://azure.microsoft.com/pt-br/free/)
* [Perguntas frequentes sobre a Conta Gratuita do Azure](https://azure.microsoft.com/pt-br/free/free-account-faq/)
* [Tutorial Criando uma conta no Microsoft Azure e utilizando os créditos gratuitos](https://www.youtube.com/watch?v=tAixhiHmphA)

**Todos esses serviços disponibilizam uma camada gratuita para testes. Isso significa que você não precisará gastar nenhum centavo para usufruir dessas tecnologias.**

Você também pode optar por uma camada paga. O custo varia, mas no geral, é bem baixo.

---

## Telemetria do APP

Para telemetria do App, utilizo o Serviço [App Center](https://appcenter.ms) da Microsoft.

É um serviço muito legal e várias funcionalidades são gratuitas. Veja: [https://azure.microsoft.com/pt-br/pricing/details/app-center/](https://azure.microsoft.com/pt-br/pricing/details/app-center/)

Na classe [App.xaml.cs](https://github.com/angelobelchior/IntelligentApp/blob/master/IntelligentApp/App.xaml.cs) temos o método 

```csharp
        protected override void OnStart()
        {
            AppCenter.Start("ios=;" +
                            "android=",
                            typeof(Analytics), typeof(Crashes));
        }
```

Caso você queira usar o App Center, será necessário criar uma conta e registrar os App. 

Após o registro, informe as chaves do iOS e do Android.

---

## Biblioteca de Terceiros

O **IntelligentApp** utiliza algumas bibliotecas de terceiros. São elas:

[Xam.Plugin.Media](https://github.com/jamesmontemagno/MediaPlugin) - [MIT License](https://github.com/jamesmontemagno/MediaPlugin/blob/master/LICENSE)

[Plugin.Permissions](https://github.com/jamesmontemagno/PermissionsPlugin) - [MIT License](https://github.com/jamesmontemagno/PermissionsPlugin/blob/master/LICENSE)

[Plugin.CurrentActivity](https://github.com/jamesmontemagno/CurrentActivityPlugin) - [MIT License](https://github.com/jamesmontemagno/CurrentActivityPlugin/blob/master/LICENSE)

[Version.Plugin](https://github.com/mtrinder/Xamarin.Plugins/tree/master/Version) - [MIT License](https://github.com/mtrinder/Xamarin.Plugins/blob/master/LICENSE)

[Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) - [MIT License](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md)

## Contribua

Esse é um projeto Open Source com [licença MIT](https://github.com/angelobelchior/IntelligentApp/blob/master/LICENSE)

Sinta-se a vontade para enviar seu Pull Request.

Críticas/Dúvidas/Sugestões são sempre bem-vidas.