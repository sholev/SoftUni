<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>

<c:set var="contextPath" value="${pageContext.request.contextPath}" />

<html>
	<head>
		<title>Add lend:</title>
	</head>	
	<body>
		<h1>
			Add lend:
		</h1>
		<form:form method="POST" action="${contextPath}${addLendUrl}" modelAttribute="Lend">
			<table>					
				<tr>
					<td>Id</td>
					<td><input type="number" name="id"></td>
				</tr>
				<tr>
					<td>Select Book:</td>
					<td>
						<select name="bookId">
						<c:forEach var="book" items="${books}">
							<option value="${book.getId()}">${book.getName()}</option>
						</c:forEach>
						</select>
					</td>
				</tr>
				<tr>
					<td>Select Client:</td>
					<td>
						<select name="clientId">
						<c:forEach var="client" items="${clients}">
							<option value="${client.getId()}">${client.getName()}</option>
						</c:forEach>
						</select>
					</td>
				</tr>
				<tr>
					<td>Lend Date</td>
					<td><input type="date" name="lendDate"></td>
				</tr>
				<tr>
					<td>Return Date</td>
					<td><input type="date" name="returnDate"></td>
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