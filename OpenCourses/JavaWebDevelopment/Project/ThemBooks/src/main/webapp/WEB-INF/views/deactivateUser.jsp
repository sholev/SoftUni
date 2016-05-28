<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>

<c:set var="contextPath" value="${pageContext.request.contextPath}" />

<html>
	<head>
		<title>Deactivate user:</title>
	</head>	
	<body>
		<h1>
			Deactivate user:
		</h1>
		<form:form method="POST" action="${contextPath}${deactivateUserUrl}" modelAttribute="User">
			<table>
				<tr>
					<td>Id</td>
					<td><input type="number" name="id"></td>
				</tr>
			</table>
		
			<button onclick="goBack()">Go Back</button>
			<input type="submit" value="Deactivate">
		</form:form>
		
		<script>
			function goBack() {
			    window.history.back();
			}
		</script>
			
	</body>
</html>