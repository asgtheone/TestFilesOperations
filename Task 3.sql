with temp as
(
select c.FullName,
		c.ConsultID,
	   month(s.SaleDate) as salesmonth,
	   (case month(s.SaleDate) when  month(getdate())-1  then s.SaleAmount end) as LastMonth,
	   (case month(s.SaleDate) when  month(getdate()) then s.SaleAmount end) as ThisMonth
from [dbo].[Consultants] c 
	inner join [dbo].[Sales] s on c.ConsultID = s.ConsultID
where year(s.SaleDate) = year(getdate()) and (MONTH(s.SaleDate) between month(getdate())-1 and MONTH(getdate()) )
)
select t.FullName, sum(t.LastMonth) as LastMonthAmount, sum(t.ThisMonth) as ThisMonthAmount, count(t.ThisMonth) as ThisMonthCount
from temp t
group by t.FullName,t.ConsultID
