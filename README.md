# IntelligentApp

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
        public const string EmotionApiKey = "";
        public const string FaceApiKey = "";
        public const string VisionApiKey = "";
        public const string CustomVisionsApiKey = "";

        public const string CustomVisionsApiEndpoint = "";
    }
```

* **EmotionApiKey**: [Clique Aqui para Obter uma chave](https://azure.microsoft.com/pt-br/try/cognitive-services/?api=emotion-api)
* **FaceApiKey**: [Clique Aqui para Obter uma chave](https://azure.microsoft.com/pt-br/try/cognitive-services/?api=face-api)
* **VisionApiKey**: [Clique Aqui para Obter uma chave](https://azure.microsoft.com/pt-br/try/cognitive-services/?api=computer-vision)
* **CustomVisionsApiKey** e **CustomVisionsApiEndpoint**: Esse serviço ainda está em _preview_. Para obter as chaves e o endpoint de testes é necessário criar uma conta em [https://www.customvision.ai/](https://www.customvision.ai/)

**Você vai precisar ter uma conta no Microsoft Azure. Você pode criar gratuitamente.**

Para maiores informações:

* [Crie sua conta gratuita do Azure hoje mesmo](https://azure.microsoft.com/pt-br/free/)
* [Perguntas frequentes sobre a Conta Gratuita do Azure](https://azure.microsoft.com/pt-br/free/free-account-faq/)
* [Tutorial Criando uma conta no Microsoft Azure e utilizando os créditos gratuitos](https://www.youtube.com/watch?v=tAixhiHmphA)

**Todos esses serviços disponibilizam uma camada gratuita para testes. Isso significa que você não precisará gastar nenhum centavo para usufruir dessas tecnologias.**

Você também pode optar por uma camada paga. O custo varia, mas no geral, é bem baixo.

---

## Contribua

Esse é um projeto Open Source com [licença MIT](https://github.com/angelobelchior/IntelligentApp/blob/master/LICENSE)

Sinta-se a vontade para enviar seu Pull Request.

Críticas/Dúvidas/Sugestões são sempre bem-vidas.