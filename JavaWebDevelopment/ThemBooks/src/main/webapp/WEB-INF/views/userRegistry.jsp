<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>

<c:set var="contextPath" value="${pageContext.request.contextPath}" />
<html>
	<head>
		<title>Users</title>
	</head>
	<body>
		<h1>
			Users:
		</h1>		

		<div>Logged in as: <sec:authentication property="principal.username" /></div>
		
		<table>
			<thead>
				<tr>
					<form:form method="GET" action="${contextPath}${userRegistryUrl}" modelAttribute="UserSearch">
						<td></td>
						<td><input type="text" name="username"></td>
						<td><input type="text" name="status"></td>
						<td><input type="text" name="name"></td>
						<td><input type=submit value="Filter"/></td>
					</form:form>
				</tr>
				<tr>
					<td>Id</td>
					<td>Username</td>
					<td>Status</td>
					<td>Name</td>
					<td>Roles</td>
				</tr>
			</thead>
			<c:if test="${not empty users}">
		    	<tbody>
			        <c:forEach var="user" items="${users}">
			            <tr>
			            	<td>${user.id}.</td>
			                <td>${user.username}</td>
			                <td>${user.status}</td>
			                <td>${user.name}</td>
			                <td>${user.roles}</td>
			            </tr>
			        </c:forEach>
		        </tbody>
			</c:if>
		</table>

		<sec:authorize access="hasRole('ROLE_ADMIN')">
			<button type="button" onclick="location = '${contextPath}${addUserUrl}'">Add</button>
			<button type="button" onclick="location = '${contextPath}${deactivateUserUrl}'">Deactivate</button>
		</sec:authorize>
		<form action="${contextPath}/logout" method="POST">
			<input type="submit" value="Log out" />
			<input type="hidden" name="${_csrf.parameterName}" value="${_csrf.token}"/>
		</form>
	</body>
</html>