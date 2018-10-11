/****** Object:  Table [dbo].[TempPosts]    Script Date: 10/09/2018 12:51:32 ******/
SET IDENTITY_INSERT [dbo].[TempPosts] ON
INSERT [dbo].[TempPosts] ([ID], [PostTypesID], [Title], [PostUrl], [ScheduleDate], [Description], [AuthorID], [ComplexityLevelsID], [Keywords], [CategoryID], [Contents], [Status], [LikeCounts], [CommentCounts], [Date], [PostStatusID]) VALUES (2, 1, N'Moq Mocking Framework With xUnit.net Unit Test In C#', NULL, CAST(0xCD3E0B00 AS Date), N'In this article, we will configure Moq Mocking Framework with xUnit.net unit testing framework.
', 4, 1, N'Keyowrd', 1, N'<p><strong>What are Mocking Frameworks?&nbsp;</strong><br />
<br />
Mocking Frameworks (Moq, NSubstitute, Rhino Mocks, FakeItEasy, and NMock3) are used to create fake objects. We can stub, i.e., completely replace the body of member and function. It is used to isolate each dependency and help developers in performing unit testing in a concise, quick, and reliable way.<br />
<br />
Creating mock objects manually is very difficult and time-consuming. So, to increase your productivity, you can go for the automatic generation of mock objects by using a Mocking Framework. A developer can build his/her unit test by using any of the NUnit, MbUnit, MSTest, xUnit etc. unit test frameworks.<br />
<br />
<strong>Description&nbsp;</strong><br />
<br />
In this article, we will configure Moq Mocking Framework with xUnit.net unit testing framework.<br />
<br />
<strong>Prerequisite</strong></p>

<ul>
	<li><a href="https://www.c-sharpcorner.com/article/setup-xunit-net-unit-testing-in-visual-studio-2017-basic-01/" rel="noopener">Basic knowledge about xUnit.net unit test (Required)</a></li>
	<li><a href="https://visualstudio.microsoft.com/downloads/" rel="noopener" target="_blank">Visual Studio 2017 Enterprise (Required)</a></li>
	<li><a href="https://www.c-sharpcorner.com/article/unit-testicode-coverage/" rel="noopener">Code coverage concepts (Optinal)</a></li>
</ul>

<p><strong>Step 1&nbsp;</strong><br />
<br />
Create a library project (&quot;TDD.xUnit.net.Client&quot;) and set up xUnit.net unit test project. If you are not aware of setting up Xunit unit test project, then refer to the article -&nbsp;<a href="https://www.c-sharpcorner.com/article/setup-xunit-net-unit-testing-in-visual-studio-2017-basic-01/">Setup xUnit.net Unit Testing In Class Library Project</a>.<br />
<br />
<strong>Step 2&nbsp;</strong><br />
<br />
Create a library project (&quot;Calculator.Lib&quot;) and a test project (&quot;TDD.xUnit.net.Client&quot;) as in the following screen.</p>

<p>&nbsp;</p>

<p><img alt="Moq Mocking Framework With xUnit.net Unit Test In C#" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/moq-mocking-framework-with-xunit-net-testing-fr/Images/image001.png" /></p>

<p>&nbsp;</p>

<p><strong>Step 3&nbsp;</strong><br />
<br />
Open &quot;ICalculator.cs&quot; file from &quot;Calculator.Lib&quot; project and add the following lines of code.</p>

<ol start="1">
	<li>namespace&nbsp;CalculatorLib&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;interface&nbsp;ICalculator&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;decimal&nbsp;Add(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2);&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;decimal&nbsp;Substract(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2);&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;decimal&nbsp;Multiply(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2);&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;decimal&nbsp;Divide(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2);&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p><strong>Step 4</strong><br />
<br />
So far, we have not implemented interface &quot;ICalculator.cs&quot;. Now, let&#39;s try to write a unit test case. What do you think? Is it possible to write a unit test case for ICalculator interface without using a mocking framework? Think for a while! No, absolutely not, because you cannot create an instance of an interface so&nbsp;you can&#39;t write a unit test for the interface without a mocking framework.<br />
<br />
<strong>Step 5&nbsp;</strong><br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and add the following lines of code.&nbsp;</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;ICalculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;&nbsp;</li>
</ol>

<p><img alt="Moq Mocking Framework With xUnit.net Unit Test In C#" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/moq-mocking-framework-with-xunit-net-testing-fr/Images/image002.png" />&nbsp;</p>

<p>&nbsp;</p>

<p><strong>Step 6</strong><br />
<br />
Now, let us install the Moq Mocking Framework. You can install this either by running a command in Package Manager Console or just by searching NuGet Package Manager. Let&#39;s install it by Package Manager Console by running the below command.&nbsp;</p>

<ol start="1">
	<li>Install-Package&nbsp;Moq&nbsp;-Version&nbsp;4.9.0&nbsp;&nbsp;&nbsp;</li>
</ol>

<p>From the above screen, you can see Moq mocking framework which has been installed in the highlighted project. Now, let&#39;s write the unit test for interface ICalculator.</p>

<p>&nbsp;</p>

<p><strong>Step 7&nbsp;</strong><br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and replace the following lines of code.</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;Moq;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;ICalculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;Mock&lt;ICalculator&gt;();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;calculator.Setup(x&nbsp;=&gt;&nbsp;x.Add(2,&nbsp;2)).Returns(4);&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Object.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p>Now, you can see we are able to write, debug, and run the unit test case as in the below screen.</p>

<p>What are the other options except for mocking framework? Here, you can create a fake object manually without using the mocking framework. You can create FakeCalculator class just by inheriting ICalculator class. Let&#39;s create a fake object manually.&nbsp;</p>

<p>&nbsp;</p>

<p><strong>Step 8&nbsp;</strong><br />
<br />
Open &quot;FakeCalculator.cs&quot; file from &quot;Calculator.Lib&quot; project and add the following lines of code.</p>

<ol start="1">
	<li>using&nbsp;System;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;CalculatorLib&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;FakeCalculator&nbsp;:&nbsp;ICalculator&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;decimal&nbsp;Add(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;num1&nbsp;+&nbsp;num2;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;decimal&nbsp;Divide(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;throw&nbsp;new&nbsp;NotImplementedException();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;decimal&nbsp;Multiply(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;throw&nbsp;new&nbsp;NotImplementedException();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;decimal&nbsp;Substract(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;throw&nbsp;new&nbsp;NotImplementedException();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;&nbsp;</li>
</ol>

<p>This is how you can create a fake object as above. We implemented the body of &quot;Add&quot; method, only the rest of the methods did not implement as in &quot;FakeCalculator&quot; class.</p>

<p>&nbsp;</p>

<p><strong>Step 9&nbsp;</strong><br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and add the following lines of code.</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;Moq;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;AddTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;FakeCalculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(5,&nbsp;calculator.Add(2,&nbsp;3));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;MultiplyTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;FakeCalculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(6,&nbsp;calculator.Multiply(2,&nbsp;3));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;ICalculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;Mock&lt;ICalculator&gt;();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;calculator.Setup(x&nbsp;=&gt;&nbsp;x.Add(2,&nbsp;2)).Returns(4);&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Object.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p>We have written three unit tests for addition, multiplication, and mock tests. Now, let&#39;s try to run these unit tests and observe.</p>

<p>You can see that from the above screen, we cannot write a meaningful unit test for not-implemented methods without a mock test framework. Now, let&#39;s try to write the unit test cases for implemented and not implemented methods with a mock testing framework.<br />
<br />
<u><strong>Note</strong></u><br />
Using Moq mocking framework, we can mock and stub only virtual or abstract methods. This is the limitation of the Moq mocking framework<strong>.&nbsp;</strong>If you try to mock or stub virtual and abstract methods you will get the exception as below screen.<br />
<br />
Now, let us add the virtual keyword in methods to make the method virtual and let&#39;s see the output of unit testing.<br />
<br />
<strong>Step 10&nbsp;</strong><br />
<br />
Open &quot;FakeCalculator.cs&quot; file from &quot;Calculator.Lib&quot; project and add a virtual keyword to &quot;Multiply&quot; method as in the following lines of code.</p>

<ol start="1">
	<li>using&nbsp;System;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;CalculatorLib&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;FakeCalculator&nbsp;:&nbsp;ICalculator&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;decimal&nbsp;Add(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;num1&nbsp;+&nbsp;num2;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;decimal&nbsp;Divide(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;throw&nbsp;new&nbsp;NotImplementedException();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;virtual&nbsp;decimal&nbsp;Multiply(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;throw&nbsp;new&nbsp;NotImplementedException();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;decimal&nbsp;Substract(decimal&nbsp;num1,&nbsp;decimal&nbsp;num2)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;throw&nbsp;new&nbsp;NotImplementedException();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p><strong>Step 11&nbsp;</strong><br />
<br />
Now, let&#39;s run all the unit tests and observe.</p>

<p>Now, you can see from the above screen, we are able to debug and run all unit test cases and errors.</p>

<p>&nbsp;</p>

<p>There are many advantages if you use the Moq mocking testing framework instead of a real one or without mocking framework. There are two types of groups - the first ones love to write real unit tests without using any mocking framework and others love to write mock unit tests with mocking testing framework. Each group has their own logic, and pros and cons behind this belief.&nbsp;</p>

<p>&nbsp;</p>

<p><strong>Real Unit Tests Writer Group&nbsp;</strong><br />
<br />
They believe that we are testing real objects instead of the fake or mock object so I also understand this belief.</p>

<p>&nbsp;</p>

<p><strong>Moq Unit Tests Writer Group&nbsp;</strong></p>

<p>This group believes we should not write unit tests of real objects, as in the unit test we are only testing the piece of code, not the entire object. In the real object there should be complex dependencies, for example network, database, and unmanaged code. These objects are very expensive and time-consuming and if these object services go down then your entire unit test will fail since it is time-consuming, so it would discourage you to write fast and reliable and available unit tests. One more point here is, we are writing unit tests, not integration tests;&nbsp; both are different. If we write real unit tests then somehow we are writing the integration test, not the unit test.</p>

<p>&nbsp;</p>

<p><strong>What I believe</strong><br />
<br />
We should use both real and moq unit tests to get the best results. We should write real unit test cases for none dependent or no dependencies (database, network, and unmanaged code) objects and for dependent objects, we should use moq tests. In this way we can minimize the complexity of dependency and it would allow writing more available, reliable and fast unit test cases. I hope you guys have learned about Moq mocking framework.<br />
<br />
<strong>Step 11 -</strong>&nbsp;<strong>Done</strong>.<br />
<br />
Congratulations! You have successfully learned what Moq is and how to configure Moq mocking framework in C#. If you have any query or concern, just let me know or just put it in the comment box and I will respond as soon as possible. I am open to discussing anything, even silly questions as well. If you have any suggestions related to this article, please let me know and I promise I will improve this article to a maximum level.<br />
<br />
<strong>Summary&nbsp;</strong><br />
<br />
In this article, we have learned what is Moq and how to configure Moq mocking framework in C#.</p>
', 0, 0, 0, CAST(0xCE3E0B00 AS Date), NULL)
INSERT [dbo].[TempPosts] ([ID], [PostTypesID], [Title], [PostUrl], [ScheduleDate], [Description], [AuthorID], [ComplexityLevelsID], [Keywords], [CategoryID], [Contents], [Status], [LikeCounts], [CommentCounts], [Date], [PostStatusID]) VALUES (3, 1, N'Code Coverage In xUnit.net Unit Test Projects In Visual Studio Enterprise 2017', NULL, CAST(0xCD3E0B00 AS Date), N'In this tutorial, we will understand the code coverage concepts in Visual Studio 2017 Enterprise and will learn how to include and exclude necessary parts of the code step by step from scratch in Visual Studio 2017 Enterprise', 4, 1, N'Keyowrd', 1, N'<p>In this tutorial, we will understand the code coverage concepts in Visual Studio 2017 Enterprise and will learn how to include and exclude necessary parts of the code step by step from scratch in Visual Studio 2017 Enterprise.<br />
<br />
Prerequisite</p>

<ul>
	<li><a href="https://www.c-sharpcorner.com/article/setup-xunit-net-unit-testing-in-visual-studio-2017-basic-01/" target="_blank">Basic knowledge about xUnit.net unit test</a></li>
	<li><a href="https://visualstudio.microsoft.com/downloads/" rel="nofollow" target="_blank">Visual Studio 2017 Enterprise</a></li>
</ul>

<p><strong>Step 1&nbsp;</strong><br />
<br />
Create a library project (&quot;TDD.xUnit.net.Client&quot;) and setup xUnit.net unit test project. If you are not aware of setting up Xunit unit test project, then refer to the article -&nbsp;<a href="https://www.c-sharpcorner.com/article/setup-xunit-net-unit-testing-in-visual-studio-2017-basic-01/" target="_blank">Setup xUnit.net Unit Testing In Class Library Project</a>.</p>

<p><br />
<strong>Step 2&nbsp;</strong><br />
<br />
Create a library project (&quot;Calculator.Lib&quot;) and a test project (&quot;TDD.xUnit.net.Client&quot;) as in the following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image001.png" /></p>

<p><br />
<strong>Step 3</strong><br />
<br />
Open &quot;Calculator.cs&quot; file from &quot;Calculator.Lib&quot; project and add the following lines of code.</p>

<ol start="1">
	<li>namespace&nbsp;CalculatorLib&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Calculator&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;Add(int&nbsp;x,&nbsp;int&nbsp;y)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if&nbsp;(x&nbsp;==&nbsp;0&nbsp;&amp;&amp;&nbsp;y&nbsp;==&nbsp;0)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;0;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;x&nbsp;+&nbsp;y;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p><strong>Step 4</strong><br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and add following lines of code.</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;Calculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(0,&nbsp;calculator.Add(0,&nbsp;0));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p><strong>Step 5</strong><br />
<br />
Now, build your solution and open the code coverage window from VS 2017 Enterprise from menu Tests=&gt;Analyze Code Coverage=&gt;All Tests as in the following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image002.png" /></p>

<p><br />
Once you click on &quot;All Tests&quot;, you will see the &quot;Code Coverage Result&quot; window as in the&nbsp;following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image003.png" />&nbsp;</p>

<p><br />
Here, one question arises, which is, why are we getting 100% code coverage? We have an extra line of code, except&nbsp; the &quot;Add&quot; method of &quot;Calculator&quot; class because we excluded all lines of code of the &quot;CalculatorTests&quot; class with the help of the attribute &quot;ExcludeFromCodeCoverage,&quot; and we are testing all possible scenarios of the Add method of calculator class; i.e., passing zero and non zero values to add method.<br />
<br />
<strong>Step 6&nbsp;</strong><br />
<br />
Now, let&#39;s do one more experiment and comment zero assertion in xUnit unit tests as in&nbsp; the following screen.<br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and add the following line of code.</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;Calculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Assert.Equal(0,&nbsp;calculator.Add(0,&nbsp;0));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;&nbsp;</li>
</ol>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image004.png" /></p>

<p><br />
Now, you can see that the code coverage has been reduced and is 71.43 % because we have commented the zero assertion and are not touching zero value logic in the add method in the calculator class from the above screen. Now, we are not covering 28.57% of the code; i.e., only 71.43% of the code is being unit tested and 28.57% of the code is not being unit tested.<br />
<br />
If you write more code and do not write a unit test then code coverage will be decreased; if you write a unit test then code coverage will be increased.<br />
<br />
If there is any difficult-to-test code, for example, network, database, unit test, class, or method etc. just use attribute</p>

<p>&quot;[ExcludeFromCodeCoverage]&quot; either class or method level. I hope now it is clear what code coverage is and how to control it.<br />
<br />
<strong>Step 7 -&nbsp;</strong>Done.<br />
<br />
Congratulations! You have successfully learned what&nbsp; code coverage is and how to control the code coverage in Visual Studio 2017 Enterprise. If you have any query or concern, just let me know or just put in the comment box and I will respond as soon as possible. I am open to discussing anything, even silly questions as well. If you have any suggestions related to this article, please let me know and I promise I will improve this article to a maximum level.<br />
<br />
<strong>Summary</strong><br />
<br />
In this article, we have learned what code coverage is and how to control it&nbsp; in Visual Studio 2017 Enterprise in C#.</p>
', 0, 0, 0, CAST(0xCE3E0B00 AS Date), NULL)
INSERT [dbo].[TempPosts] ([ID], [PostTypesID], [Title], [PostUrl], [ScheduleDate], [Description], [AuthorID], [ComplexityLevelsID], [Keywords], [CategoryID], [Contents], [Status], [LikeCounts], [CommentCounts], [Date], [PostStatusID]) VALUES (4, 1, N'Setup xUnit.net Unit Testing In Class Library Project', NULL, CAST(0xCD3E0B00 AS Date), N'In this article, we will learn how to set up xUnit.net in the class library project step by step from scratch in Visual Studio 2017.', 4, 1, N'Keyowrd', 1, N'<p>In this tutorial, we will understand the code coverage concepts in Visual Studio 2017 Enterprise and will learn how to include and exclude necessary parts of the code step by step from scratch in Visual Studio 2017 Enterprise.<br />
<br />
Prerequisite</p>

<ul>
	<li><a href="https://www.c-sharpcorner.com/article/setup-xunit-net-unit-testing-in-visual-studio-2017-basic-01/" target="_blank">Basic knowledge about xUnit.net unit test</a></li>
	<li><a href="https://visualstudio.microsoft.com/downloads/" rel="nofollow" target="_blank">Visual Studio 2017 Enterprise</a></li>
</ul>

<p><strong>Step 1&nbsp;</strong><br />
<br />
Create a library project (&quot;TDD.xUnit.net.Client&quot;) and setup xUnit.net unit test project. If you are not aware of setting up Xunit unit test project, then refer to the article -&nbsp;<a href="https://www.c-sharpcorner.com/article/setup-xunit-net-unit-testing-in-visual-studio-2017-basic-01/" target="_blank">Setup xUnit.net Unit Testing In Class Library Project</a>.</p>

<p><br />
<strong>Step 2&nbsp;</strong><br />
<br />
Create a library project (&quot;Calculator.Lib&quot;) and a test project (&quot;TDD.xUnit.net.Client&quot;) as in the following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image001.png" /></p>

<p><br />
<strong>Step 3</strong><br />
<br />
Open &quot;Calculator.cs&quot; file from &quot;Calculator.Lib&quot; project and add the following lines of code.</p>

<ol start="1">
	<li>namespace&nbsp;CalculatorLib&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Calculator&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;Add(int&nbsp;x,&nbsp;int&nbsp;y)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if&nbsp;(x&nbsp;==&nbsp;0&nbsp;&amp;&amp;&nbsp;y&nbsp;==&nbsp;0)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;0;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;x&nbsp;+&nbsp;y;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p><strong>Step 4</strong><br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and add following lines of code.</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;Calculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(0,&nbsp;calculator.Add(0,&nbsp;0));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p><strong>Step 5</strong><br />
<br />
Now, build your solution and open the code coverage window from VS 2017 Enterprise from menu Tests=&gt;Analyze Code Coverage=&gt;All Tests as in the following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image002.png" /></p>

<p><br />
Once you click on &quot;All Tests&quot;, you will see the &quot;Code Coverage Result&quot; window as in the&nbsp;following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image003.png" />&nbsp;</p>

<p><br />
Here, one question arises, which is, why are we getting 100% code coverage? We have an extra line of code, except&nbsp; the &quot;Add&quot; method of &quot;Calculator&quot; class because we excluded all lines of code of the &quot;CalculatorTests&quot; class with the help of the attribute &quot;ExcludeFromCodeCoverage,&quot; and we are testing all possible scenarios of the Add method of calculator class; i.e., passing zero and non zero values to add method.<br />
<br />
<strong>Step 6&nbsp;</strong><br />
<br />
Now, let&#39;s do one more experiment and comment zero assertion in xUnit unit tests as in&nbsp; the following screen.<br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and add the following line of code.</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;Calculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Assert.Equal(0,&nbsp;calculator.Add(0,&nbsp;0));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;&nbsp;</li>
</ol>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image004.png" /></p>

<p><br />
Now, you can see that the code coverage has been reduced and is 71.43 % because we have commented the zero assertion and are not touching zero value logic in the add method in the calculator class from the above screen. Now, we are not covering 28.57% of the code; i.e., only 71.43% of the code is being unit tested and 28.57% of the code is not being unit tested.<br />
<br />
If you write more code and do not write a unit test then code coverage will be decreased; if you write a unit test then code coverage will be increased.<br />
<br />
If there is any difficult-to-test code, for example, network, database, unit test, class, or method etc. just use attribute</p>

<p>&quot;[ExcludeFromCodeCoverage]&quot; either class or method level. I hope now it is clear what code coverage is and how to control it.<br />
<br />
<strong>Step 7 -&nbsp;</strong>Done.<br />
<br />
Congratulations! You have successfully learned what&nbsp; code coverage is and how to control the code coverage in Visual Studio 2017 Enterprise. If you have any query or concern, just let me know or just put in the comment box and I will respond as soon as possible. I am open to discussing anything, even silly questions as well. If you have any suggestions related to this article, please let me know and I promise I will improve this article to a maximum level.<br />
<br />
<strong>Summary</strong><br />
<br />
In this article, we have learned what code coverage is and how to control it&nbsp; in Visual Studio 2017 Enterprise in C#.</p>
', 0, 0, 0, CAST(0xCE3E0B00 AS Date), NULL)
INSERT [dbo].[TempPosts] ([ID], [PostTypesID], [Title], [PostUrl], [ScheduleDate], [Description], [AuthorID], [ComplexityLevelsID], [Keywords], [CategoryID], [Contents], [Status], [LikeCounts], [CommentCounts], [Date], [PostStatusID]) VALUES (5, 1, N'Install Jenkins ( DevOps ) On Windows Machine Step By Step', NULL, CAST(0xCD3E0B00 AS Date), N'In this article, we will learn how to install and set up Jenkins on a Windows machine', 4, 1, N'Keyowrd', 1, N'<p>In this tutorial, we will understand the code coverage concepts in Visual Studio 2017 Enterprise and will learn how to include and exclude necessary parts of the code step by step from scratch in Visual Studio 2017 Enterprise.<br />
<br />
Prerequisite</p>

<ul>
	<li><a href="https://www.c-sharpcorner.com/article/setup-xunit-net-unit-testing-in-visual-studio-2017-basic-01/" target="_blank">Basic knowledge about xUnit.net unit test</a></li>
	<li><a href="https://visualstudio.microsoft.com/downloads/" rel="nofollow" target="_blank">Visual Studio 2017 Enterprise</a></li>
</ul>

<p><strong>Step 1&nbsp;</strong><br />
<br />
Create a library project (&quot;TDD.xUnit.net.Client&quot;) and setup xUnit.net unit test project. If you are not aware of setting up Xunit unit test project, then refer to the article -&nbsp;<a href="https://www.c-sharpcorner.com/article/setup-xunit-net-unit-testing-in-visual-studio-2017-basic-01/" target="_blank">Setup xUnit.net Unit Testing In Class Library Project</a>.</p>

<p><br />
<strong>Step 2&nbsp;</strong><br />
<br />
Create a library project (&quot;Calculator.Lib&quot;) and a test project (&quot;TDD.xUnit.net.Client&quot;) as in the following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image001.png" /></p>

<p><br />
<strong>Step 3</strong><br />
<br />
Open &quot;Calculator.cs&quot; file from &quot;Calculator.Lib&quot; project and add the following lines of code.</p>

<ol start="1">
	<li>namespace&nbsp;CalculatorLib&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Calculator&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;Add(int&nbsp;x,&nbsp;int&nbsp;y)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if&nbsp;(x&nbsp;==&nbsp;0&nbsp;&amp;&amp;&nbsp;y&nbsp;==&nbsp;0)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;0;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;x&nbsp;+&nbsp;y;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p><strong>Step 4</strong><br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and add following lines of code.</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;Calculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(0,&nbsp;calculator.Add(0,&nbsp;0));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p><strong>Step 5</strong><br />
<br />
Now, build your solution and open the code coverage window from VS 2017 Enterprise from menu Tests=&gt;Analyze Code Coverage=&gt;All Tests as in the following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image002.png" /></p>

<p><br />
Once you click on &quot;All Tests&quot;, you will see the &quot;Code Coverage Result&quot; window as in the&nbsp;following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image003.png" />&nbsp;</p>

<p><br />
Here, one question arises, which is, why are we getting 100% code coverage? We have an extra line of code, except&nbsp; the &quot;Add&quot; method of &quot;Calculator&quot; class because we excluded all lines of code of the &quot;CalculatorTests&quot; class with the help of the attribute &quot;ExcludeFromCodeCoverage,&quot; and we are testing all possible scenarios of the Add method of calculator class; i.e., passing zero and non zero values to add method.<br />
<br />
<strong>Step 6&nbsp;</strong><br />
<br />
Now, let&#39;s do one more experiment and comment zero assertion in xUnit unit tests as in&nbsp; the following screen.<br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and add the following line of code.</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;Calculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Assert.Equal(0,&nbsp;calculator.Add(0,&nbsp;0));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;&nbsp;</li>
</ol>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image004.png" /></p>

<p><br />
Now, you can see that the code coverage has been reduced and is 71.43 % because we have commented the zero assertion and are not touching zero value logic in the add method in the calculator class from the above screen. Now, we are not covering 28.57% of the code; i.e., only 71.43% of the code is being unit tested and 28.57% of the code is not being unit tested.<br />
<br />
If you write more code and do not write a unit test then code coverage will be decreased; if you write a unit test then code coverage will be increased.<br />
<br />
If there is any difficult-to-test code, for example, network, database, unit test, class, or method etc. just use attribute</p>

<p>&quot;[ExcludeFromCodeCoverage]&quot; either class or method level. I hope now it is clear what code coverage is and how to control it.<br />
<br />
<strong>Step 7 -&nbsp;</strong>Done.<br />
<br />
Congratulations! You have successfully learned what&nbsp; code coverage is and how to control the code coverage in Visual Studio 2017 Enterprise. If you have any query or concern, just let me know or just put in the comment box and I will respond as soon as possible. I am open to discussing anything, even silly questions as well. If you have any suggestions related to this article, please let me know and I promise I will improve this article to a maximum level.<br />
<br />
<strong>Summary</strong><br />
<br />
In this article, we have learned what code coverage is and how to control it&nbsp; in Visual Studio 2017 Enterprise in C#.</p>
', 0, 0, 0, CAST(0xCE3E0B00 AS Date), NULL)
INSERT [dbo].[TempPosts] ([ID], [PostTypesID], [Title], [PostUrl], [ScheduleDate], [Description], [AuthorID], [ComplexityLevelsID], [Keywords], [CategoryID], [Contents], [Status], [LikeCounts], [CommentCounts], [Date], [PostStatusID]) VALUES (6, 1, N'Setup Angular 6 Development Environment In Visual Studio 2017 In ASP.NET MVC Step By Step', NULL, CAST(0xCD3E0B00 AS Date), N'In this article, we will learn how to set up an Angular 6 development environment in Visual Studio 2017 without using Angular CLI.', 4, 1, N'Keyowrd', 1, N'<p>In this tutorial, we will understand the code coverage concepts in Visual Studio 2017 Enterprise and will learn how to include and exclude necessary parts of the code step by step from scratch in Visual Studio 2017 Enterprise.<br />
<br />
Prerequisite</p>

<ul>
	<li><a href="https://www.c-sharpcorner.com/article/setup-xunit-net-unit-testing-in-visual-studio-2017-basic-01/" target="_blank">Basic knowledge about xUnit.net unit test</a></li>
	<li><a href="https://visualstudio.microsoft.com/downloads/" rel="nofollow" target="_blank">Visual Studio 2017 Enterprise</a></li>
</ul>

<p><strong>Step 1&nbsp;</strong><br />
<br />
Create a library project (&quot;TDD.xUnit.net.Client&quot;) and setup xUnit.net unit test project. If you are not aware of setting up Xunit unit test project, then refer to the article -&nbsp;<a href="https://www.c-sharpcorner.com/article/setup-xunit-net-unit-testing-in-visual-studio-2017-basic-01/" target="_blank">Setup xUnit.net Unit Testing In Class Library Project</a>.</p>

<p><br />
<strong>Step 2&nbsp;</strong><br />
<br />
Create a library project (&quot;Calculator.Lib&quot;) and a test project (&quot;TDD.xUnit.net.Client&quot;) as in the following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image001.png" /></p>

<p><br />
<strong>Step 3</strong><br />
<br />
Open &quot;Calculator.cs&quot; file from &quot;Calculator.Lib&quot; project and add the following lines of code.</p>

<ol start="1">
	<li>namespace&nbsp;CalculatorLib&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Calculator&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;Add(int&nbsp;x,&nbsp;int&nbsp;y)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if&nbsp;(x&nbsp;==&nbsp;0&nbsp;&amp;&amp;&nbsp;y&nbsp;==&nbsp;0)&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;0;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;x&nbsp;+&nbsp;y;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p><strong>Step 4</strong><br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and add following lines of code.</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;Calculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(0,&nbsp;calculator.Add(0,&nbsp;0));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;</li>
</ol>

<p><strong>Step 5</strong><br />
<br />
Now, build your solution and open the code coverage window from VS 2017 Enterprise from menu Tests=&gt;Analyze Code Coverage=&gt;All Tests as in the following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image002.png" /></p>

<p><br />
Once you click on &quot;All Tests&quot;, you will see the &quot;Code Coverage Result&quot; window as in the&nbsp;following screen.<br />
&nbsp;</p>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image003.png" />&nbsp;</p>

<p><br />
Here, one question arises, which is, why are we getting 100% code coverage? We have an extra line of code, except&nbsp; the &quot;Add&quot; method of &quot;Calculator&quot; class because we excluded all lines of code of the &quot;CalculatorTests&quot; class with the help of the attribute &quot;ExcludeFromCodeCoverage,&quot; and we are testing all possible scenarios of the Add method of calculator class; i.e., passing zero and non zero values to add method.<br />
<br />
<strong>Step 6&nbsp;</strong><br />
<br />
Now, let&#39;s do one more experiment and comment zero assertion in xUnit unit tests as in&nbsp; the following screen.<br />
<br />
Open &quot;CalculatorTests.cs&quot; file from &quot;TDD.xUnit.net.Client&quot; project and add the following line of code.</p>

<ol start="1">
	<li>using&nbsp;CalculatorLib;&nbsp;&nbsp;</li>
	<li>using&nbsp;System.Diagnostics.CodeAnalysis;&nbsp;&nbsp;</li>
	<li>using&nbsp;Xunit;&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;</li>
	<li>namespace&nbsp;TDD.xUnit.net.Client&nbsp;&nbsp;</li>
	<li>{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeFromCodeCoverage]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CalculatorTests&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Fact]&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;void&nbsp;PassingTest()&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;calculator&nbsp;=&nbsp;new&nbsp;Calculator();&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(4,&nbsp;calculator.Add(2,&nbsp;2));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Assert.Equal(0,&nbsp;calculator.Add(0,&nbsp;0));&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</li>
	<li>}&nbsp;&nbsp;&nbsp;</li>
</ol>

<p><img alt="Code Coverage in xUnit.net Unit Tests Projects in Visual Studio Enterprise 2017" src="https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/unit-testicode-coverage/Images/image004.png" /></p>

<p><br />
Now, you can see that the code coverage has been reduced and is 71.43 % because we have commented the zero assertion and are not touching zero value logic in the add method in the calculator class from the above screen. Now, we are not covering 28.57% of the code; i.e., only 71.43% of the code is being unit tested and 28.57% of the code is not being unit tested.<br />
<br />
If you write more code and do not write a unit test then code coverage will be decreased; if you write a unit test then code coverage will be increased.<br />
<br />
If there is any difficult-to-test code, for example, network, database, unit test, class, or method etc. just use attribute</p>

<p>&quot;[ExcludeFromCodeCoverage]&quot; either class or method level. I hope now it is clear what code coverage is and how to control it.<br />
<br />
<strong>Step 7 -&nbsp;</strong>Done.<br />
<br />
Congratulations! You have successfully learned what&nbsp; code coverage is and how to control the code coverage in Visual Studio 2017 Enterprise. If you have any query or concern, just let me know or just put in the comment box and I will respond as soon as possible. I am open to discussing anything, even silly questions as well. If you have any suggestions related to this article, please let me know and I promise I will improve this article to a maximum level.<br />
<br />
<strong>Summary</strong><br />
<br />
In this article, we have learned what code coverage is and how to control it&nbsp; in Visual Studio 2017 Enterprise in C#.</p>
', 0, 0, 0, CAST(0xCE3E0B00 AS Date), NULL)
SET IDENTITY_INSERT [dbo].[TempPosts] OFF
