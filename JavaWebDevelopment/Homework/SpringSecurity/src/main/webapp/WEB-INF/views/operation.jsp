<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Banking Operation</title>
	</head>
	<body>
		<form>
			<p> Logged in as <b><sec:authentication property="principal.username" /></b>.</p>
			<p> ${output} </p>					
			<c:if test="${not empty accountIds}">
				<table>
					<tr>
						<td>Select Account: </td>
						<td>
							<select name="selectedAccountId">
							<c:forEach var="id" items="${accountIds}">
								<option value="${id}">${id}</option>
							</c:forEach>
							</select>
						</td>
					</tr>
					<tr>
						<td>Operation: </td>
						<td>
							<input type="radio" name="selectedOperation" value="deposit">Deposit
							<input type="radio" name="selectedOperation" value="withdraw">Withdraw
						</td>
					</tr>
					<tr>
						<td>Amount: </td>
						<td><input type="number" name="operationAmmount" value="${operationAmmount}"></td>
					</tr>
					<tr>
						<td>Currency: </td>
						<td>
							<select name="selectedCurrency">
								<option value="USD">USD</option>
								<option value="EUR">EUR</option>
								<option value="GBP">GBP</option>
								<option value="BGN">BGN</option>
							</select>
						</td>
					</tr>			
				</table>
				<input type="submit" value="Submit"  formaction="/lebank/operation" method="POST">
			</c:if>
			<input type="submit" value="Back" formaction="/lebank/" method="GET">
		</form>
	</body>
</html>