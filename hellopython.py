dai = float  (input("Nhap chieu dai cua hinh chu nhat(cm):"))
rong = float (input("Nhap chieu rong cua hinh chu nhat(cm):"))
cao = float (input ("Nhap chieu cao cua  hinh chu nhat(cm):"))
count_le =0
if int (dai)%2!=0:
    count_le +=1
if int (rong)%2!=0:
    count_le +=1
if int (cao)  %2!=0:
    count_le +=1
    dien_tich=dai*rong 
    the_tich =dai*rong*cao
    print("so luong so le can hien thi :", count_le)
print("dien tich day hinh chu nhat =", round(dien_tich, 2), "cm^2")
print("the tich khoi =", round(the_tich, 2), "cm^3")

