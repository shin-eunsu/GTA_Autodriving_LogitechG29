# Create date : 2019.02.25 (Eunsu)

# graphics : NVIDIA GeForce RTX 2080 SUPER

# OS
# windows10 pro

# Anaconda 2019.10 for windows (Python 3.7 version) 64bit
# https://repo.anaconda.com/archive/Anaconda3-2019.10-Windows-x86_64.exe


# anaconda prompt 관리자 권한으로 실행

#####################################
# conda create -n [name] python=3.6 #
#####################################

import os

# Run this script from within an anaconda virtual environment to install the required packages
# Be sure to run this script as root or as administrator.

os.system('pip install tensorflow-gpu==1.8.0')
os.system('conda install -y matplotlib pandas h5py')
os.system('conda install -yc conda-forge opencv')
os.system('conda install -yc conda-forge ipywidgets')
os.system('pip install keras==2.1.2')
os.system('pip install image')
os.system('pip install keras-tqdm')
os.system('pip install airsim')
os.system('pip install notebook==5.7.5')



