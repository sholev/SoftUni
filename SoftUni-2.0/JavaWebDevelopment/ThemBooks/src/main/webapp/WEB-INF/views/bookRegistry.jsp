<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>

<c:set var="contextPath" value="${pageContext.request.contextPath}" />
<html>
	<head>
		<title>Books</title>
	</head>
	<body>
		<h1>
			Books:
		</h1>		
	
		<div>
			<form action="${contextPath}/logout" method="POST">
				Logged in as <b><sec:authentication property="principal.username" /></b>
				<input type="submit" value="Log out" />
				<input type="hidden" name="${_csrf.parameterName}" value="${_csrf.token}"/>
			</form>	
									
			<sec:authorize access="hasRole('ROLE_ADMIN')">
				<button type="button" onclick="location = '${contextPath}${userRegistryUrl}'">User Registry</button>
			</sec:authorize>			
			<button type="button" onclick="location = '${contextPath}${bookRegistryUrl}'">Book Registry</button>
			<button type="button" onclick="location = '${contextPath}${clientRegistryUrl}'">Client Registry</button>
			<button type="button" onclick="location = '${contextPath}${lendRegistryUrl}'">Lend Registry</button>
		</div>
		
		<table>
			<thead>
				<tr>
					<form:form method="GET" action="${contextPath}${bookRegistryUrl}" modelAttribute="BookSearch">
						<td></td>
						<td><input type="text" name="name"></td>
						<td><input type="text" name="author"></td>
						<td><input type="date" name="publishDate"></td>
						<td><input type=submit value="Filter"/></td>
					</form:form>
				</tr>
				<tr>
					<td>Id</td>
					<td>Name</td>
					<td>Author</td>
					<td>Publish Date</td>
					<td>Pages</td>
				</tr>
			</thead>
			<c:if test="${not empty books}">
		    	<tbody>
			        <c:forEach var="book" items="${books}">
			            <tr>
			            	<td>${book.id}.</td>
			                <td>${book.name}</td>
			                <td>${book.author}</td>
			                <td>${book.publishDate}</td>
			                <td>${book.pages}</td>			                
							<td><button type="button" onclick="location = '${contextPath}${editBookUrl}${book.toUrl()}'">Edit</button></td>
							<td><button type="button" onclick="location = '${contextPath}${deleteBookUrl}${book.toUrl()}'">Delete</button></td>
			            </tr>
			        </c:forEach>
		        </tbody>
			</c:if>
		</table>
		
		<button type="button" onclick="location = '${contextPath}${addBookUrl}'">Add New Book</button>
	
	</body>
</html>