function xoa(cr7)
		{
			var i=confirm("Bạn chắc muốn xóa không?");
			if(i==true){
			var i = cr7.parentNode.parentNode.rowIndex;
    document.getElementById("bangad").deleteRow(i);
		}
	}