<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>

<c:set var="contextPath" value="${pageContext.request.contextPath}" />
<html>
	<head>
		<title>Clients</title>
	</head>
	<body>
		<h1>
			Clients:
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
					<form:form method="GET" action="${contextPath}${clientkRegistryUrl}" modelAttribute="Client">
						<td></td>
						<td><input type="text" name="name"></td>
						<td><input type="text" name="PID"></td>
						<td><input type="date" name="birthDate"></td>
						<td><input type=submit value="Filter"/></td>
					</form:form>
				</tr>
				<tr>
					<td>Id</td>
					<td>Name</td>
					<td>PID</td>
					<td>Birth Date</td>
				</tr>
			</thead>
			<c:if test="${not empty clients}">
		    	<tbody>
			        <c:forEach var="client" items="${clients}">
			            <tr>
			            	<td>${client.id}.</td>
			                <td>${client.name}</td>
			                <td>${client.pid}</td>
			                <td>${client.birthDate}</td>	                
							<td><button type="button" onclick="location = '${contextPath}${editClientUrl}${client.toUrl()}'">Edit</button></td>
							<td><button type="button" onclick="location = '${contextPath}${deleteClientUrl}${client.toUrl()}'">Delete</button></td>
			            </tr>
			        </c:forEach>
		        </tbody>
			</c:if>
		</table>
		
		<button type="button" onclick="location = '${contextPath}${addClientUrl}'">Add New Client</button>
	
	</body>
</html>