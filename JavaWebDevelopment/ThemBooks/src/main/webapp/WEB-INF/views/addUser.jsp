<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>

<c:set var="contextPath" value="${pageContext.request.contextPath}" />

<html>
	<head>
		<title>Add user:</title>
	</head>	
	<body>
		<h1>
			Add user:
		</h1>
		<form:form method="POST" action="${contextPath}${addUserUrl}" modelAttribute="User">
			<table>					
				<tr>
					<td>Id</td>
					<td><input type="number" name="id"></td>
				</tr>
				<tr>
					<td>Username</td>
					<td><input type="text" name="username"></td>
				</tr>
				<tr>
					<td>Password</td>
					<td><input type="password" name="password"></td>
				</tr>
				<tr>
					<td>Name</td>
					<td><input type="text" name="name"></td>
				</tr>
				<tr>
					<td>Roles</td>
					<td><input type="text" name="roles"></td>
				</tr>
			</table>
		
			<button onclick="goBack()">Go Back</button>
			<input type="submit" value="Submit">
		</form:form>
		
		<form action="${contextPath}/logout" method="POST">
			<input type="submit" value="Log out" />
			<input type="hidden" name="${_csrf.parameterName}" value="${_csrf.token}"/>
		</form>
		<script>
			function goBack() {
			    window.history.back();
			}
		</script>
			
	</body>
</html>