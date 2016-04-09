<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>

<c:set var="contextPath" value="${pageContext.request.contextPath}" />

<html>
	<head>
		<title>Edit book:</title>
	</head>	
	<body>
		<h1>
			Edit book:
		</h1>
		<form:form method="POST" action="${contextPath}${editBookUrl}" modelAttribute="Book">
			<table>					
				<tr>
					<td>Id</td>
					<td><input readonly type="number" name="id" value="${book.id}"></td>
				</tr>
				<tr>
					<td>Name</td>
					<td><input type="text" name="name" value="${book.name}"></td>
				</tr>
				<tr>
					<td>Author</td>
					<td><input type="text" name="author" value="${book.author}"></td>
				</tr>
				<tr>
					<td>Publish Date</td>
					<td><input type="date" name="publishDate" value="${book.publishDate}"></td>
				</tr>
				<tr>
					<td>Pages</td>
					<td><input type="number" name="pages" value="${book.pages}"></td>
				</tr>
			</table>
		
			<button onclick="goBack()">Cancel</button>
			<input type="submit" value="Submit">
		</form:form>
		
		<script>
			function goBack() {
			    window.history.back();
			}
		</script>
			
	</body>
</html>