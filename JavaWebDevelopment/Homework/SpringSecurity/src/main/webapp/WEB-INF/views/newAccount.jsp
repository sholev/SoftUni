<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Account Creation</title>
	</head>
	<body>
		<form>
			<p> Logged in as <b><sec:authentication property="principal.username" /></b>.</p>
			<p> ${output} </p>
			<table>
				<thead>
					<tr>
						<td>N</td>
						<td>Initial Balance</td>					
						<td>Currency</td>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td>${accountNumber}</td>
						<td><input type="number" name="initialBallance" value="${initialBallance}"></td>
						<td>
							<select name="initialCurrency">
								<option value="USD">USD</option>
								<option value="EUR">EUR</option>
								<option value="GBP">GBP</option>
								<option value="BGN">BGN</option>
							</select>
						</td>
					</tr>	
				</tbody>		
			</table>
			<input type="submit" value="Submit" formaction="/lebank/newAccount" method="POST">
			<input type="submit" value="Back" formaction="/lebank/" method="GET">
		</form>
	</body>
</html>