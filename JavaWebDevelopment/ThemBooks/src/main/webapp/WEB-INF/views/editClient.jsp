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
		<form:form method="POST" action="${contextPath}${editClientUrl}" modelAttribute="Client">
			<table>					
				<tr>
					<td>Id</td>
					<td>${client.id}</td>
				</tr>
				<tr>
					<td>Name</td>
					<td><input type="text" name="name" value="${client.name}"></td>
				</tr>
				<tr>
					<td>PID</td>
					<td><input type="text" name="pid" value="${client.pid}"></td>
				</tr>
				<tr>
					<td>Publish Date</td>
					<td><input type="date" name="birthDate" value="${client.birthDate}"></td>
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