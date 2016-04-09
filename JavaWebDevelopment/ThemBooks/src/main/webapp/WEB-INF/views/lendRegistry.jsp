<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>

<c:set var="contextPath" value="${pageContext.request.contextPath}" />
<html>
	<head>
		<title>Lends</title>
	</head>
	<body>
		<h1>
			Lends:
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
					<form:form method="GET" action="${contextPath}${lendRegistryUrl}" modelAttribute="LendSearch">
						<td></td>
						<td><input type="text" name="bookName"></td>
						<td><input type="text" name="clientName"></td>
						<td><input type="date" name="lendDate"></td>
						<td><input type="date" name="returnDate"></td>
						<td><input type=submit value="Filter"/></td>
					</form:form>
				</tr>
				<tr>
					<td>Id.</td>
					<td>Book</td>
					<td>Client</td>
					<td>Lend Date</td>
					<td>Return Date</td>
				</tr>
			</thead>
			<c:if test="${not empty lends}">
		    	<tbody>
			        <c:forEach var="lend" items="${lends}">
			            <tr>
			            	<td>${lend.id}.</td>
			            	<td>${lend.book.name}</td>
			                <td>${lend.client.name}</td>
			                <td>${lend.lendDate}</td>
			                <td>${lend.returnDate}</td>	                
							<td>
								<sec:authorize access="hasRole('ROLE_ADMIN')">
									<button type="button" onclick="location = '${contextPath}${editLendUrl}${lend.toUrl()}'">Edit</button>
								</sec:authorize>							
							</td>
			            </tr>
			        </c:forEach>
		        </tbody>
			</c:if>
		</table>
		
		<button type="button" onclick="location = '${contextPath}${addLendUrl}'">Add New Lend</button>
	
	</body>
</html>