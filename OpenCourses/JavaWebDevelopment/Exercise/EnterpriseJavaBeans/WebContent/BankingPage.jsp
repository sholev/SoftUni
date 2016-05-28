<%@ page language="java" contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>

<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>Banking page homework</title>
	</head>
	<body>
		<form action="BankingPage.jsp" method="post">
		
			<%=request.getAttribute("output") == null ? "" : request.getAttribute("output") + "<br>"%>
			Client ID: 
			<input type="text" name="userId" value="<%=request.getAttribute("userId") == null ? "" : request.getAttribute("userId")%>">
			<%=request.getAttribute("balance") == null ? "" : "<br>Client balance: " + request.getAttribute("balance") + " BGN"%>
			<br>		
			Operation: 
			<input type="radio" name="action" value="deposit">Deposit
			<input type="radio" name="action" value="withdraw">Withdraw
			<br>
			Amount: <input type="number" name="amount" value="0">
			<select name="currency">
				<option value="usd">USD</option>
				<option value="eur">EUR</option>
				<option value="gbp">GPB</option>
				<option value="bgn">BGN</option>
			</select>
			<input type="submit" value="Submit">	
		</form>
		<br><br>
		<div id="footer">		
		<%=request.getAttribute("date")%><br>
		<%=request.getAttribute("project")%> <br>
		<%=request.getAttribute("version")%>
		</div>
	</body>
</html>
